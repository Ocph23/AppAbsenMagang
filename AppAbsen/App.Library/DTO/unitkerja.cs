using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace AppAbsen.Library.DTO
{
    [TableName("unitkerja")]
    public class unitkerja : BaseNotify
    {
        [PrimaryKey("IdUnitKerja")]
        [DbColumn("IdUnitKerja")]
        public string IdUnitKerja
        {
            get { return _idunitkerja; }
            set
            {
                SetProperty(ref _idunitkerja, value);
            }
        }

        [DbColumn("NamaUnitKerja")]
        public string NamaUnitKerja
        {
            get { return _namaunitkerja; }
            set
            {
                SetProperty(ref _namaunitkerja, value);
            }
        }

        private string _idunitkerja;
        private string _namaunitkerja;
    }
}


