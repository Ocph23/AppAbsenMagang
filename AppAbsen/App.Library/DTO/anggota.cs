using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace App.Library.DTO
{
    [TableName("anggota")]
    public class anggota : BaseNotifyProperty
    {
        [PrimaryKey("IdMahasiswa")]
        [DbColumn("IdMahasiswa")]
        public string IdMahasiswa
        {
            get { return _idmahasiswa; }
            set
            {
                SetProperty(ref _idmahasiswa, value);
            }
        }

        [DbColumn("Nama")]
        public string Nama
        {
            get { return _nama; }
            set
            {
                SetProperty(ref _nama, value);
            }
        }

        [DbColumn("TempatLahir")]
        public string TempatLahir
        {
            get { return _tempatlahir; }
            set
            {
                SetProperty(ref _tempatlahir, value);
            }
        }

        [DbColumn("TglLahir")]
        public DateTime TglLahir
        {
            get { return _tgllahir; }
            set
            {
                SetProperty(ref _tgllahir, value);
            }
        }

        [DbColumn("Agama")]
        public string Agama
        {
            get { return _agama; }
            set
            {
                SetProperty(ref _agama, value);
            }
        }

        [DbColumn("JenisKelamin")]
        public string JenisKelamin
        {
            get { return _jeniskelamin; }
            set
            {
                SetProperty(ref _jeniskelamin, value);
            }
        }

        [DbColumn("Alamat")]
        public string Alamat
        {
            get { return _alamat; }
            set
            {
                SetProperty(ref _alamat, value);
            }
        }

        [DbColumn("AsalUniversitas")]
        public string AsalUniversitas
        {
            get { return _asaluniversitas; }
            set
            {
                SetProperty(ref _asaluniversitas, value);
            }
        }

        [DbColumn("AsalSekolah")]
        public string AsalSekolah
        {
            get { return _asalsekolah; }
            set
            {
                SetProperty(ref _asalsekolah, value);
            }
        }

        [DbColumn("IdUnitKerja")]
        public string IdUnitKerja
        {
            get { return _idunitkerja; }
            set
            {
                SetProperty(ref _idunitkerja, value);
            }
        }

        private string _idmahasiswa;
        private string _nama;
        private string _tempatlahir;
        private DateTime _tgllahir;
        private string _agama;
        private string _jeniskelamin;
        private string _alamat;
        private string _asaluniversitas;
        private string _asalsekolah;
        private string _idunitkerja;
    }
}


