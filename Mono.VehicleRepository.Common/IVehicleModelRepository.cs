using Mono.Common;
using Mono.Models;
using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository.Common
{
    public interface IVehicleModelRepository
    {
        /// <summary>
        /// Gets VehicleModels that match passed parameter of filter.SearchBy 
        /// and all other parameters for filtering, pagin, sorting that match filter prop.
        /// Returns IEnumerable of VehicleModel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<IVehicleModel> GetVehiclesModel(IFilter filter, IPaging paging, ISorting sort);

        /// <summary>
        /// Gets VehicleModel with id match of passed id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IVehicleModel GetVehicleModel(Guid id);

        /// <summary>
        /// Gets VehicleModel count by search
        /// </summary>
        /// <param name="searchby"></param>
        /// <returns>Integer- number of items</returns>
        int GetVehicleModelCount(string searchby);

        /// <summary>
        /// Adds VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        Task<int> AddVehicleModelToSelectionAsync(IVehicleModel vehicleModel);

        /// <summary>
        /// Removes VehicleModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        Task<int> RemoveVehicleModelFromSelectionAsync(Guid id);

        /// <summary>
        /// Updates VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        Task<int> UpdateVehicleModelFromSelectionAsync(IVehicleModel vehicleModel);
    }
}
