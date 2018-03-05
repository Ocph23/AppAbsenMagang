using App.Library.DTO;
using AppAbsen.Library;
using AppAbsen.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.Models
{
    public class RekapAbsenContext
    {

        public List<rekapabsen> GetSource(DateTime date)
        {

            using (var db = new OcphDbContext())
            {
                var result = from b in db.Anggotas.Select()
                             join a in db.Absens.Where(o=>o.Tanggal.Month== date.Month && o.Tanggal.Year==date.Year) 
                             on b.IdMahasiswa equals a.IdMahasiswa into Tampungabsen
                             select new anggota
                             { 
                                 Absens= (from data in Tampungabsen select data).ToList(), 
                                 IdMahasiswa= b.IdMahasiswa,
                                 Nama = b.Nama
                             };
                List<rekapabsen> datakirim = new List<rekapabsen>();
              
                foreach(var value in result)
                {
                    rekapabsen temp = new rekapabsen();
                    temp.IdMahasiswa = value.IdMahasiswa;
                    temp.Nama = value.Nama;
                    temp.Hadir = value.Absens.Count(o => o.Hadir == Status.Ya);
                    temp.Alpa = value.Absens.Count(o => o.Alpa == Status.Ya);
                    temp.Ijin= value.Absens.Count(o => o.Ijin== Status.Ya);
                    temp.Sakit = value.Absens.Count(o => o.Sakit == Status.Ya);
                    datakirim.Add(temp);
                }
                return datakirim;

            }
        }
    }
}
