using App.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.Models
{
   public class UnitKerjaContext
    {
        public UnitKerjaContext()
        {

        }

        private List<unitkerja> source;

        public List<unitkerja> Source
        {
            get {
                if (source == null)
                    source = GetSource();
                return source; }
            set { source = value; }
        }

        private List<unitkerja> GetSource()
        {
            using (var db = new OcphDbContext())
            {
                return db.UnitKerja.Select().ToList();
            }
        }
    }
}
