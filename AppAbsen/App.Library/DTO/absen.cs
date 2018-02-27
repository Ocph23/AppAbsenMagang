using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace AppAbsen.Library.DTO
{
    [TableName("absen")]
    public class absen : BaseNotify
    {
        [PrimaryKey("IdAbsen")]
        [DbColumn("IdAbsen")]
        public int IdAbsen
        {
            get { return _idabsen; }
            set
            {
                SetProperty(ref _idabsen, value);
            }
        }

        [DbColumn("IdMahasiswa")]
        public string IdMahasiswa
        {
            get { return _idmahasiswa; }
            set
            {
                SetProperty(ref _idmahasiswa, value);
            }
        }

        [DbColumn("Tanggal")]
        public DateTime Tanggal
        {
            get { return _tanggal; }
            set
            {
                SetProperty(ref _tanggal, value);
            }
        }

        [DbColumn("Bulan")]
        public string Bulan
        {
            get { return _bulan; }
            set
            {
                SetProperty(ref _bulan, value);
            }
        }

        [DbColumn("WaktuMasuk")]
        public TimeSpan WaktuMasuk
        {
            get { return _waktumasuk; }
            set
            {
                SetProperty(ref _waktumasuk, value);
            }
        }

        [DbColumn("WaktuPulang")]
        public TimeSpan WaktuPulang
        {
            get { return _waktupulang; }
            set
            {
                SetProperty(ref _waktupulang, value);
            }
        }

        [DbColumn("Hadir")]
        public Status Hadir
        {
            get { return _hadir; }
            set
            {
                SetProperty(ref _hadir, value);
            }
        }

        [DbColumn("Alpa")]
        public Status Alpa
        {
            get { return _alpa; }
            set
            {
                SetProperty(ref _alpa, value);
            }
        }

        [DbColumn("Ijin")]
        public Status Ijin
        {
            get { return _ijin; }
            set
            {
                SetProperty(ref _ijin, value);
            }
        }

        [DbColumn("Sakit")]
        public Status Sakit
        {
            get { return _sakit; }
            set
            {
                SetProperty(ref _sakit, value);
            }
        }

        [DbColumn("Keterangan")]
        public string Keterangan
        {
            get { return _keterangan; }
            set
            {
                SetProperty(ref _keterangan, value);
            }
        }

        public anggota Anggota { get; internal set; }

        private int _idabsen;
        private string _idmahasiswa;
        private DateTime _tanggal;
        private string _bulan;
        private TimeSpan _waktumasuk;
        private TimeSpan _waktupulang;
        private Status _hadir;
        private Status _alpa;
        private Status _ijin;
        private Status _sakit;
        private string _keterangan;
    }
}


