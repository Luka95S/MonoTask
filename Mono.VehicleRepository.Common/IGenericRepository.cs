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
        Task<T> Get<T>(Guid id) where T : class;
        Task<T> GetWhere<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetAll<T>() where T : class;
        Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class;

        Task<int> Add<T>(T entity) where T : class;
        Task<int> Update<T>(T entity) where T : class;
        Task<int> Delete<T>(T entity) where T : class;
        Task<int> Delete<T>(Guid id) where T : class;
        IQueryable<T> GetWhereQuery<T>() where T : class;
    }
}
