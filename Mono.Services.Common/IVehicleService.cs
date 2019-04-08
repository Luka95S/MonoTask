using Mono.Common;
using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono.Services.Common
{
    public interface IVehicleService
    {
        /// <summary>
        /// Gets all VehicleMake that match to filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<IVehicleMake> GetAllVehicles(IFilter filter);

        /// <summary>
        /// Gets VehicleMake by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<IVehicleMake> GetVehicleQuery(string query);

        /// <summary>
        /// Gets VehicleMake identifier that match VehicleMake name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IVehicleMake GetVehicleMakeByName(string name);

        /// <summary>
        /// Gets VehicleMake count that match searchby
        /// </summary>
        /// <param name="searchby"></param>
        /// <returns></returns>
        int GetVehicleCount(string searchby);

        /// <summary>
        /// Gets VehicleMake by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);

        /// <summary>
        /// Adds VehicleMake to database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<int> AddVehiclesAsync(IVehicleMake vehicle);

        /// <summary>
        /// Removes VehicleMake by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> RemoveVehicleAsync(Guid id);

        /// <summary>
        /// Updates VehicleMakes
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> UpdateVehicleAsync(IVehicleMake vehicle, Guid id );
    }
}
