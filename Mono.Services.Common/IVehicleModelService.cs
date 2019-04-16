using Mono.Common;
using Mono.Models;
using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Services.Common
{
    public interface IVehicleModelService
    {
        /// <summary>
        /// Gets all VehicleModels that match to filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IVehicleModel GetAllVehicles(IFilter filter, IPaging paging, ISorting sort, IEmbedCollection embed);

        /// <summary>
        /// Gets VehicleModel by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IVehicleModel GetVehicleModel(Guid id);

        /// <summary>
        /// Adds VehicleModel to database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<int> AddVehiclesModelAsync(IVehicleModel vehicle);

        /// <summary>
        /// Removes VehicleModel by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> RemoveVehicleModelAsync(Guid id);

        /// <summary>
        /// Updates VehicleModel
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<int> UpdateVehicleModelAsync(IVehicleModel vehicle);

        /// <summary>
        /// Gets VehicleModel count that match searchby
        /// </summary>
        /// <param name="searchby"></param>
        /// <returns></returns>
        int GetVehicleModelCount(string searchby);
    }
}
