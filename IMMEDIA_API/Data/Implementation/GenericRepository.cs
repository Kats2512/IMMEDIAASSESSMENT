using Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public IMMEDIAEntities _context = null;
        public DbSet<T> table = null;

        //Constructor
        public GenericRepository()
        {
            this._context = new IMMEDIAEntities();
            table = _context.Set<T>();
        }
        public GenericRepository(IMMEDIAEntities _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        //Get all data from entity framework object
        public async Task<IList<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        //Query entity framework to get only record from object
        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        //Insert data into an entity framework object
        public void Insert(T obj)
        {
            table.Add(obj);
        }

        //Update changes via entity framework
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        //Delete changes via entity framework
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        //Save changes via entity framework
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        //Execute SQL Procs
        public async Task<IList<T>> ExecuteCustomStoredProc<T>(string commandName, SqlParameter parameter)
        {
            return await this._context.Database.SqlQuery<T>(commandName, parameter).ToListAsync();
        }

        public async Task<T> ExecuteCustomStoredProcSingleItem<T>(string commandName, SqlParameter parameter)
        {
            return await this._context.Database.SqlQuery<T>(commandName, parameter).FirstOrDefaultAsync();
        }
    }
}
