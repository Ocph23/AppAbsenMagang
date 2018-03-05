using AppAbsen.Library;
using AppAbsen.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.DTO
{
    public class absentanggal
    {
        public string IdMahasiswa { get; set; }
        public string Nama { get; set; }
        public TimeSpan JamMasuk { get; set; }
        public TimeSpan JamPulang { get; set; }
        public Status Keterangan { get; set; }
        public List<absen> Absens { get; set; }
    }
}
