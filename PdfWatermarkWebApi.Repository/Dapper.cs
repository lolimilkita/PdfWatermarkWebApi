using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfWatermarkWebApi.Repository
{
    public interface IDapper
    {
        IDbConnection GetConnection();

        IEnumerable<T> QueryMain<T>(string sql, dynamic? param = null, IDbTransaction? transaction = null);

        int ExecuteMain(string sql, dynamic? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }

    public class Dapper : IDapper
    {
        private readonly IDatabaseConnectionFactory _database;
        private readonly IUnitOfWork _unitOfWork;

        public Dapper(IDatabaseConnectionFactory databaseConnectionFactory, IUnitOfWork unitOfWork)
        {
            _database = databaseConnectionFactory;
            _unitOfWork = unitOfWork;
        }

        public IDbConnection GetConnection()
        {
            return _database.CreateConnection();
        }

        private IEnumerable<T> Query<T>(string sql, dynamic? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var conn = _database.CreateConnection())
                {
                    return SqlMapper.Query<T>(conn, sql, param, transaction, buffered, commandTimeout, commandType);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int Execute(string sql, dynamic? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var conn = _database.CreateConnection())
                {
                    return SqlMapper.Execute(conn, sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteMain(string sql, dynamic? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                return Execute(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> QueryMain<T>(string sql, dynamic? param = null, IDbTransaction? transaction = null)
        {
            try
            {
                return Query<T>(sql, param, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
