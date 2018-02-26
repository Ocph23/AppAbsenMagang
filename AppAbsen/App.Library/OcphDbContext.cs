using App.Library.DTO;
using DAL.DContext;
using DAL.Repository;
using System;
using System.Data;

namespace App.Library
{
    public class OcphDbContext : IDbContext, IDisposable
    {
        private string ConnectionString;
        private IDbConnection _Connection;

        public OcphDbContext(string constring)
        {

            this.ConnectionString = constring;
        }

        public OcphDbContext()
        {
            this.ConnectionString = "server = localhost; uid = root; pwd = ; database = Absen";
        }

        internal IRepository<absen> Absens { get { return new Repository<absen>(this); } }
        internal IRepository<anggota> Anggotas { get { return new Repository<anggota>(this); } }
        internal IRepository<unitkerja> UnitKerja { get { return new Repository<unitkerja>(this); } }

        public IDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new MySqlDbContext(this.ConnectionString);
                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }


        public void Dispose()
        {
            if (_Connection != null)
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
        }
    }
}
