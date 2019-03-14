using Microsoft.EntityFrameworkCore;
using Mono.DBContext;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository
{
    public class GenericRepository: IGenericRepository
    {
        private readonly VehicleDBContext context;

        public GenericRepository(VehicleDBContext context)
        {
            this.context = context;
        }

        public async Task<int> Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }


        public async Task<int> Delete<T>(Guid id) where T : class
        {
            T entity = await Get<T>(id);
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<T> GetWhere<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await context.Set<T>().FirstOrDefaultAsync(match);
        }


        public async Task<T> Get<T>(Guid id) where T : class
        {
            var response = await context.Set<T>().FindAsync(id);
            return response;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            var response = await context.Set<T>().ToListAsync();
            return response;
        }

        public async Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<int> Update<T>(T entity) where T : class
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public IQueryable<T> GetWhereQuery<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}
