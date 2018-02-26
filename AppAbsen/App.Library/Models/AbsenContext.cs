using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Library.DTO;

namespace App.Library.Models
{
    public class AbsenContext
    {
        private List<absen> source;

        public AbsenContext()
        {

        }

        public List<absen> TodayCollection {
            get
            {
                if (source == null)
                {
                    source = this.GetSource();
                }
                var now = DateTime.Now;
                return source.Where(O=>O.Tanggal.Day == now.Day && O.Tanggal.Month==now.Month && O.Tanggal.Year==now.Year).ToList();
            }
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

        public bool AddNewAbsen(absen absen)
        {
            using (var db = new OcphDbContext())
            {
                absen.IdAbsen = db.Absens.InsertAndGetLastID(absen);
                if(absen.IdAbsen>0)
                {
                    TodayCollection.Add(absen);
                    return true;
                }else
                {
                    return false;
                }
            }
        }

        public ObservableCollection<absen> GetTodaySource()
        {
            return new ObservableCollection<absen>(TodayCollection);
        }
    }
}
