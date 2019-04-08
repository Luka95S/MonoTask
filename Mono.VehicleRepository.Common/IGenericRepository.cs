using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository.Common
{
    public interface IGenericRepository
    {
        /// <summary>
        /// Async Task Get method of open class type (T) with id parameter.
        /// Takes id parameter and gets model that suits model id property.
        /// Returns model as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(Guid id) where T : class;

        /// <summary>
        /// Async Task GetWhere method of open class type (T).
        /// Takes function as parameter where match suits model property and gets that model.
        /// Returns model as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<T> GetWhereAsync<T>(Expression<Func<T, bool>> match) where T : class;

        /// <summary>
        /// Async Task GetAll method of open class type (T).
        /// Takes class and get all models that suits class.
        /// Returns list of class models as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;

        /// <summary>
        /// Async Task GetWhere method of open class type (T).
        /// Takes function as parameter where match suits model property and gets that model.
        /// Returns model as result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        IQueryable<T> GetWhereQuery<T>() where T : class;

        /// <summary>
        /// Async Task method that takes all vehicles in range that is set with lambda expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class;

        /// <summary>
        /// Async Task Add method of open class type (T).
        /// Saves data to database and returns integer value depending on the result of SaveChangesAsync().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>integer (0 for fail and 1 for success)</returns>
        Task<int> AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Updates model of open class type (T).
        /// Takes class type and model, updates it and save changes.
        /// Returns integer value that match result. 0 - fail, result >= 1 - success
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Async Task Delete method of open class type (T) with model parameter.
        /// Removes model from database and save changes.
        /// Returns integer as result. (result == 0 ? fail : success)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity) where T : class;

        /// <summary>
        /// Async Task Delete method of open class type (T) with id parameter.
        /// Gets model with id parameter and remove it from database.
        /// Then saves changes and returns integer value depending on the result of SaveChangesAsync().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>integer (0 for fail and 1 for success)</returns>
        Task<int> DeleteAsync<T>(Guid id) where T : class;
    }
}
