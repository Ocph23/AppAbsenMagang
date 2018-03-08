using App.Library.DTO;
using AppAbsen.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.Models
{
    public class AbsenTanggalContext
    {
        public List<absentanggal> GetSource(DateTime date)
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Anggotas.Select()
                             join b in db.Absens.Where(o => o.Tanggal.Month == date.Month && o.Tanggal.Day==date.Day)
                             on a.IdMahasiswa equals b.IdMahasiswa into Tampungabsen
                             select new absentanggal
                             {
                                 Absens = (from data in Tampungabsen select data).ToList(),
                                 IdMahasiswa = a.IdMahasiswa,
                                 Nama = a.Nama
                             };
                List<absentanggal> datakirim = new List<absentanggal>();

                foreach (var value in result)
                {
                    absentanggal temp = new absentanggal();
                    temp.IdMahasiswa = value.IdMahasiswa;
                    temp.Nama = value.Nama;
                    temp.Keterangan = "Alpa";
                    if(value.Absens.FirstOrDefault()!=null)
                    {
                        temp.JamMasuk = value.Absens.FirstOrDefault().WaktuMasuk;
                        temp.JamPulang = value.Absens.FirstOrDefault().WaktuPulang;
                       
                        if (value.Absens.FirstOrDefault().Hadir == Status.Ya)
                            temp.Keterangan = "Hadir";
                        else if (value.Absens.FirstOrDefault().Sakit == Status.Ya)
                            temp.Keterangan = "Sakit";
                        else
                            temp.Keterangan = "Ijin";
                    }
                    datakirim.Add(temp);
                }
                return datakirim;
            }
        }
    }
}
