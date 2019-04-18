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
        /// Gets VehicleMakes that match to filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<IVehicleMake> GetAllVehicles(IFilter filter, IPaging paging, ISorting sort, IEmbedCollection embed)
        {
            return vehicleRepository.GetVehicles(filter, paging, sort, embed);
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
        /// Gets VehicleMake identifier that match VehicleMake name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<IVehicleMake> GetVehicleMakeByName(string name)
        {
            return vehicleRepository.GetVehicleMakeByName(name);
        }
    }   

}
