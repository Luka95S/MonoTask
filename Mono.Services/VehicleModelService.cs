using Mono.Models.Common;
using Mono.Services.Common;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        public IVehicleModelRepository vehicleModelRepository { get; private set; }
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<int> AddVehiclesModelAsync(IVehicleModel vehicle)
        {
            return await vehicleModelRepository.AddVehicleModelToSelectionAsync(vehicle);
        }

        public async Task<IEnumerable<IVehicleModel>> GetAllVehiclesAsync()
        {
            return await vehicleModelRepository.GetVehiclesModelAsync();
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(Guid id)
        {
            return await vehicleModelRepository.GetVehicleModelAsync(id);
        }

        public async Task<int> RemoveVehicleModelAsync(Guid id)
        {
            return await vehicleModelRepository.RemoveVehicleModelFromSelectionAsync(id);
        }

        public async Task<int> UpdateVehicleModelAsync(IVehicleModel vehicle, Guid id)
        {
            vehicle.Id = id;
            return await vehicleModelRepository.UpdateVehicleModelFromSelectionAsync(vehicle);
        }
    }
}
