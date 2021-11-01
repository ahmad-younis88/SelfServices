using Dapper;
using SelfServices.Common.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace SelfServices.Repositry
{
    public class Dapper : IDapper, IDisposable
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DbConnection";

        public Dapper(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<T> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection();
            IEnumerable<T> ts = await db.QueryAsync<T>(sp, parms, commandType: commandType);
            return ts.FirstOrDefault();
        }

        public async Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection();
            IEnumerable<T> ts = await db.QueryAsync<T>(sp, parms, commandType: commandType);
            return ts.ToList();
        }

        public async Task<int> Insert(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int nresult;
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    nresult = await db.ExecuteAsync(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return nresult;
        }

        public async Task<int> Update(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int nresult;
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    nresult = await db.ExecuteAsync(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return nresult;
        }

        public void Dispose()
        {
        }

        private DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

    }
}
