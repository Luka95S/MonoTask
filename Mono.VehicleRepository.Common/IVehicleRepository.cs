using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mono.Common;
using Mono.Models.Common;

namespace Mono.VehicleRepository.Common
{
    public interface IVehicleRepository
    {
        #region Methods
        /// <summary>
        /// Gets VehicleMakes that match passed parameter of filter.SearchBy 
        /// and gets all other parameters for filtering, pagin, sorting that match filter prop.
        /// Returns IEnumerable of VehicleMake
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<IVehicleMake> GetVehicles(IFilter filter);

        /// <summary>
        /// Gets VehicleMake with id match of passed id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);

        /// <summary>
        /// Gets VehicleMake with id match of passed id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<IVehicleMake> GetVehicleQuery(string query);

        /// <summary>
        /// Gets VehicleMake by query parameter for prop: Name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IVehicleMake GetVehicleMakeByName(string name);

        /// <summary>
        /// Gets number of items in database by searchby parameter
        /// </summary>
        /// <param name="searchby"></param>
        /// <returns>Integer- number of items</returns>
        int GetVehiclesCount(string searchby);

        /// <summary>
        /// Adds VehicleMake
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        Task<int> AddVehicleMakeToSelectionAsync(IVehicleMake vehicleMake);

        /// <summary>
        /// Removes VehicleMake
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> RemoveVehicleFromSelectionAsync(Guid id);

        /// <summary>
        /// Updates VehicleMake
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns></returns>
        Task<int> UpdateVehicleFromSelectionAsync(IVehicleMake vehicleMake);

        #endregion Methods
    }
}
