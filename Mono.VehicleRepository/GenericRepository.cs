using Mono.DBContext;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository
{
    public class GenericRepository: IGenericRepository
    {
        protected VehicleDBContext Context { get; private set; }

        public GenericRepository(VehicleDBContext context)
        {
            this.Context = context;
        }

        public async Task<int> Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            return await Context.SaveChangesAsync();
        }


        public async Task<int> Delete<T>(Guid id) where T : class
        {
            T entity = await Get<T>(id);
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<T> GetWhere<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().FirstOrDefaultAsync(match);
        }


        public async Task<T> Get<T>(Guid id) where T : class
        {
            var response = await Context.Set<T>().FindAsync(id);
            return response;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            var response = await Context.Set<T>().ToListAsync();
            return response;
        }

        public async Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<int> Update<T>(T entity) where T : class
        {
            Context.Set<T>().Update(entity);
            return await Context.SaveChangesAsync();
        }

        public IQueryable<T> GetWhereQuery<T>() where T : class
        {
            return Context.Set<T>();
        }
    }
}
