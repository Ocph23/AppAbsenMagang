using System;
using System.Collections.Generic;
using System.Linq;
using AppAbsen.Library.DTO;

namespace AppAbsen.Library.Models
{
    public class AbsenContext
    {
        private List<absen> source;

        public List<absen> Source
        {
            get {
                if (source == null)
                    source = GetSource();
                return source; }
            set { source = value; }
        }


        private List<absen> GetSource()
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Absens.Select()
                             join b in db.Anggotas.Select() on a.IdMahasiswa equals b.IdMahasiswa
                             select new absen
                             {
                                 Alpa = a.Alpa,
                                 Bulan = a.Bulan,
                                 Hadir = a.Hadir,
                                 IdAbsen = a.IdAbsen,
                                 IdMahasiswa = a.IdMahasiswa,
                                 Ijin = a.Ijin,
                                 Keterangan = a.Keterangan,
                                 Sakit = a.Sakit,
                                 Tanggal = a.Tanggal,
                                 WaktuMasuk = a.WaktuMasuk,
                                 WaktuPulang = a.WaktuPulang,
                                 Anggota = b,
                             };
                return result.ToList();
            }
        }

        public bool Add(absen absen)
        {
            using (var db = new OcphDbContext())
            {
                absen.IdAbsen = db.Absens.InsertAndGetLastID(absen);
                if(absen.IdAbsen>0)
                {
                    Source.Add(absen);
                    return true;
                }else
                {
                    return false;
                }
            }
        }

        public bool Update(absen item)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if(db.Absens.Update(x=>new {
                        x.Alpa,
                        x.Bulan,
                        x.Hadir,
                        x.Ijin,
                        x.Keterangan,
                        x.Sakit,
                        x.Tanggal,
                        x.WaktuMasuk,
                        x.WaktuPulang
                    },item,x=>x.IdAbsen==item.IdAbsen))
                    {
                        var res = Source.Where(O => O.IdAbsen == item.IdAbsen).FirstOrDefault();
                        if (res != null)
                        {
                            res.Alpa = item.Alpa;
                            res.Bulan = item.Bulan;
                            res.Hadir = item.Hadir;
                            res.Ijin = item.Ijin;
                            res.Keterangan = item.Keterangan;
                            res.Sakit = item.Sakit;
                            res.Tanggal = item.Tanggal;
                            res.WaktuMasuk = item.WaktuMasuk;
                            res.WaktuPulang = item.WaktuPulang;
                            trans.Commit();
                            return true;
                        }
                        else
                            throw new SystemException();

                    }else
                        throw new SystemException();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(absen item)
        {

            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (db.Absens.Delete(O => O.IdAbsen== item.IdAbsen))
                    {
                        var data = Source.Where(O => O.IdAbsen == item.IdAbsen).FirstOrDefault();
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
