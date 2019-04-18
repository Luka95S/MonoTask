using Microsoft.EntityFrameworkCore;
using Mono.DAL;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository
{
    /// <summary>
    /// Set of generic CRUD methods and some other generic metods. 
    /// Methods has open type so they can be used for diffrent classes when they are called.
    /// </summary>
    public class GenericRepository : IGenericRepository
    {
        /// <summary>
        /// Gets the VehicleDBContext
        /// </summary>
        private readonly VehicleDBContext context;

        /// <summary>
        /// Inicialize instance of VehicleDBContext
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(VehicleDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Async Task Add method of open class type (T).
        /// Saves data to database and returns integer value depending on the result of SaveChangesAsync().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>integer (0 for fail and 1 for success)</returns>
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Async Task GetWhere method of open class type (T).
        /// Takes function as parameter where match suits model property and gets that model.
        /// Returns model as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<T>GetWhereAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await context.Set<T>().FirstOrDefaultAsync(match);
        }

        /// <summary>
        /// Async Task Get method of open class type (T) with id parameter.
        /// Takes id parameter and gets model that suits model id property.
        /// Returns model as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            var response = await context.Set<T>().FindAsync(id);
            return response;
        }

        /// <summary>
        /// Gets model as queryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetWhereQuery<T>() where T : class
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Async Task GetAll method of open class type (T).
        /// Takes class and get all models that suits class.
        /// Returns list of class models as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var response = await context.Set<T>().ToListAsync();
            return response;
        }

        /// <summary>
        /// Async Task method that takes all vehicles in range that is set with lambda expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await context.Set<T>().Where(match).ToListAsync();
        }
 
        /// <summary>
        /// Async Task Delete method of open class type (T) with id parameter.
        /// Gets model with id parameter and remove it from database.
        /// Then saves changes and returns integer value depending on the result of SaveChangesAsync().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>integer (0 for fail and 1 for success)</returns>
        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            T entity = await GetAsync<T>(id);
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Async Task Delete method of open class type (T) with model parameter.
        /// Removes model from database and save changes.
        /// Returns integer as result. (result == 0 ? fail : success)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates model of open class type (T).
        /// Takes class type and model, updates it and save changes.
        /// Returns integer value that match result. 0 - fail, result >= 1 - success
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
