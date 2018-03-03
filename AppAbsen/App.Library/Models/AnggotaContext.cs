using AppAbsen.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen.Library.Models
{
  public  class AnggotaContext
    {

        private List<anggota> source;

        public List<anggota> Source
        {
            get {
                if (source == null)
                    source = GetSource();
                return source; }
            set { source = value; }
        }

        private List<anggota> GetSource()
        {

            using (var db = new OcphDbContext())
            {
                var datakirim = (from a in db.Anggotas.Select()
                                 join b in db.UnitKerja.Select() on a.IdUnitKerja equals b.IdUnitKerja
                                 select new anggota
                                 {
                                     IdMahasiswa = a.IdMahasiswa,
                                     Nama = a.Nama,
                                     TempatLahir = a.TempatLahir,
                                     TglLahir = a.TglLahir,
                                     JenisKelamin = a.JenisKelamin,
                                     Agama = a.Agama,
                                     Alamat = a.Alamat,
                                     AsalUniversitas = a.AsalUniversitas,
                                     AsalSekolah = a.AsalSekolah,
                                     IdUnitKerja = b.IdUnitKerja,
                                     NamaUnitKerja = b.NamaUnitKerja
                                 }).ToList();
                return datakirim;
            }
        }

        public bool Add(anggota item)
        {
            using (var db = new OcphDbContext())
            {
                if (db.Anggotas.Insert(item))
                {
                    Source.Add(item);
                    return true;
                }
                else
                    return false;
            }
        }

        public bool Update(anggota item)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (db.Anggotas.Update(O => new
                    {
                        O.Agama,
                        O.Alamat,
                        O.AsalSekolah,
                        O.AsalUniversitas,
                        O.IdUnitKerja,
                        O.JenisKelamin,
                        O.Nama,
                        O.TempatLahir,
                        O.TglLahir
                    }, item, O => O.IdMahasiswa == item.IdMahasiswa))
                    {
                        var O = Source.Where(x => x.IdMahasiswa == item.IdMahasiswa).FirstOrDefault();
                        if (O != null)
                        {
                            O.Agama = item.Agama;
                            O.Alamat = item.Alamat;
                            O.AsalSekolah = item.AsalSekolah;
                            O.AsalUniversitas = item.AsalUniversitas;
                            O.IdUnitKerja = item.IdUnitKerja;
                            O.JenisKelamin = item.JenisKelamin;
                            O.Nama = item.Nama;
                            O.TempatLahir = item.TempatLahir;
                            O.TglLahir = item.TglLahir;
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            throw new SystemException();
                        }
                    }
                    else
                        return false;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(anggota item)
        {

            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (db.Anggotas.Delete(O => O.IdMahasiswa== item.IdMahasiswa))
                    {
                        var data = Source.Where(O => O.IdUnitKerja == item.IdUnitKerja).FirstOrDefault();
                        if (data != null)
                        {
                            Source.Remove(data);
                        }
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
