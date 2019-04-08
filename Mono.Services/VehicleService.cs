using Mono.Common;
using Mono.Models.Common;
using Mono.Services.Common;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono.Services
{
    public class VehicleService : IVehicleService
    {
        /// <summary>
        /// Gets VehicleMake repository
        /// </summary>
        public IVehicleRepository vehicleRepository { get; private set; }

        /// <summary>
        /// Inicialize instance of VehicleMakeService
        /// </summary>
        /// <param name="vehicleRepository"></param>
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Gets all VehicleMake that match to filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<IVehicleMake> GetAllVehicles(IFilter filter)
        {
            return vehicleRepository.GetVehicles(filter);
        }

        /// <summary>
        /// Gets VehicleMake by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            return await vehicleRepository.GetVehicleMakeAsync(id);
        }

        /// <summary>
        /// Adds VehicleMake to database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<int> AddVehiclesAsync(IVehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return 0;
            }
            return await vehicleRepository.AddVehicleMakeToSelectionAsync(vehicle);
        }

        /// <summary>
        /// Removes VehicleMake by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> RemoveVehicleAsync(Guid id)
        {
            return await vehicleRepository.RemoveVehicleFromSelectionAsync(id);
        }

        /// <summary>
        /// Updates VehicleMakes ****
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> UpdateVehicleAsync(IVehicleMake vehicle, Guid id)
        {
            vehicle.Id = id;
            return await vehicleRepository.UpdateVehicleFromSelectionAsync(vehicle);
        }

        /// <summary>
        /// Gets VehicleMake by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<IVehicleMake> GetVehicleQuery(string query)
        {
            return vehicleRepository.GetVehicleQuery(query);
        }

        /// <summary>
        /// Gets VehicleMake identifier that match VehicleMake name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IVehicleMake GetVehicleMakeByName(string name)
        {
            return vehicleRepository.GetVehicleMakeByName(name);
        }

        /// <summary>
        /// Gets VehicleMake count that match searchby
        /// </summary>
        /// <param name="searchby"></param>
        /// <returns></returns>
        public int GetVehicleCount(string searchby)
        {
            return vehicleRepository.GetVehiclesCount(searchby);
        }
    }   

}
