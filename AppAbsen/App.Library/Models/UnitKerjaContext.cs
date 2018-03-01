using AppAbsen.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen.Library.Models
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

        public bool Add(unitkerja item)
        {
            using (var db = new OcphDbContext())
            {
                var a = db.UnitKerja.Where(o => o.IdUnitKerja == item.IdUnitKerja).ToList();
                if (a.Count == 0)
                {
                    if (db.UnitKerja.Insert(item))
                    {
                        Source.Add(item);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
                
            }
        }

        public bool Update(unitkerja item)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (db.UnitKerja.Update(O => new { O.NamaUnitKerja }, item, O => O.IdUnitKerja == item.IdUnitKerja))
                    {
                        var data = Source.Where(O => O.IdUnitKerja == item.IdUnitKerja).FirstOrDefault();
                        if (data != null)
                        {
                            data.NamaUnitKerja = item.NamaUnitKerja;
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            throw new SystemException();
                        }
                    }
                    else
                        return false;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(unitkerja item)
        {

            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (db.UnitKerja.Delete(O => O.IdUnitKerja == item.IdUnitKerja))
                    {
                        var data = Source.Where(O => O.IdUnitKerja == item.IdUnitKerja).FirstOrDefault();
                        if (data != null)
                        {
                            Source.Remove(data);
                        }
                        trans.Commit();
                        return true;
                    }else
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
