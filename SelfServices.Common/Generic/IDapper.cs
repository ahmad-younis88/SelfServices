using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Common.Generic
{
    public interface IDapper 
    {
        Task<T> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<int> Insert(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<int> Update(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
