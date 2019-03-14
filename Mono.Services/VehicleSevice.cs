using Mono.Models.Common;
using Mono.Services.Common;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono.Services
{
    public class VehicleSevice : IVehicleService
    {
        public IVehicleRepository vehicleRepository { get; private set; }
        public VehicleSevice(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllVehiclesAsync()
        {
            return await vehicleRepository.GetVehiclesAsync();
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            return await vehicleRepository.GetVehicleMakeAsync(id);
        }

        public async Task<int> AddVehiclesAsync(IVehicleMake vehicle)
        {
            return await vehicleRepository.AddVehicleMakeToSelectionAsync(vehicle);
        }

        public async Task<int> RemoveVehicleAsync(Guid id)
        {
            return await vehicleRepository.RemoveVehicleFromSelectionAsync(id);
        }

        public async Task<int> UpdateVehicleAsync(IVehicleMake vehicle,Guid id)
        {
            vehicle.Id = id;
            return await vehicleRepository.UpdateVehicleFromSelectionAsync(vehicle);
        }

    }   

}
