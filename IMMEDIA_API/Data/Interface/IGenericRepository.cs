using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task<int> Save();
        Task<IList<T>> ExecuteCustomStoredProc<T>(string commandName, SqlParameter parameter);
        Task<T> ExecuteCustomStoredProcSingleItem<T>(string commandName, SqlParameter parameter);
    }
}
