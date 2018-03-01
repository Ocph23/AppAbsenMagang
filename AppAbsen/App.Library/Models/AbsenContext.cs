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
            try
            {
                using (var db = new OcphDbContext())
                {
                    var dataAnggota = db.Anggotas.Where(O => O.IdMahasiswa == absen.IdMahasiswa).FirstOrDefault();
                    if (dataAnggota == null)
                        throw new SystemException("Data Mahasiswa Tidak Ditemukan");
                    else
                    {
                        var dataAbsen = Source.Where(O => 
                        O.IdMahasiswa == absen.IdMahasiswa && 
                        O.Tanggal.Day == absen.Tanggal.Day &&
                        O.Tanggal.Month==absen.Tanggal.Month &&
                        O.Tanggal.Year==absen.Tanggal.Year ).FirstOrDefault();
                        DateTime today = DateTime.Now;
                        var result = CanAbsen(dataAbsen);
                        if (result == StatusBisaAbsen.Datang)
                        {
                            absen.WaktuMasuk = today.TimeOfDay;
                            absen.Hadir = Status.Ya;
                            absen.Bulan = today.Month.ToString();
                            absen.IdAbsen = db.Absens.InsertAndGetLastID(absen);
                            absen.Anggota = dataAnggota;
                            Source.Add(absen);
                            return true;
                        }
                        else
                        {
                            dataAbsen.WaktuPulang = today.TimeOfDay;
                            return db.Absens.Update(O => new { O.WaktuPulang }, dataAbsen, O => O.IdAbsen == dataAbsen.IdAbsen);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
            
        }

        private StatusBisaAbsen CanAbsen(absen ab)
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            if(time <= new TimeSpan(12, 0, 0))
            {
                if (ab == null)
                {
                    if (time <= new TimeSpan(8, 30, 0))
                    {
                        return StatusBisaAbsen.Datang;
                    }
                    else
                    {
                        throw new SystemException("Maaf Anda Terlmabat");
                    }
                }
                else
                {
                    if (time <= new TimeSpan(12, 0, 0))
                    {
                        throw new SystemException("Anda Sudah Absen Masuk Hari Ini");
                    }
                    else
                    {
                        if (ab.WaktuPulang != new TimeSpan(0, 0, 0))
                            throw new SystemException("Anda Sudah Absen Pulang Hari Ini");
                        else if (time <= new TimeSpan(16, 30, 0))
                        {
                            throw new SystemException("Maaf Belum Saatnya Absen Pulang");
                        }
                        else
                            return StatusBisaAbsen.Pulang;
                    }
                }
            }else
            {
                if (ab == null)
                    throw new SystemException("Maaf Anda Alpha Hari Ini");
                else
                {
                    if (ab.WaktuPulang != new TimeSpan(0, 0, 0))
                        throw new SystemException("Anda Sudah Absen Pulang Hari Ini");
                    else if (time <= new TimeSpan(16, 30, 0))
                    {
                        throw new SystemException("Maaf Belum Saatnya Absen Pulang");
                    }
                    else
                        return StatusBisaAbsen.Pulang;
                }
            }
           
        }

        private bool CheckStatusAbsen()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            if(time<new TimeSpan(12,0,0))
            {
                return true;
            }
            return false;
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
