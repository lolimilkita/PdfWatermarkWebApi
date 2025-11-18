using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfWatermarkWebApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        void Begin();
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        private bool _disposed = false;

        public UnitOfWork(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connection = _connectionFactory.CreateConnection();
        }

        public void Begin()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Transaction?.Dispose();

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                Connection.Dispose();

                _disposed = true;
            }
        }
    }
}
