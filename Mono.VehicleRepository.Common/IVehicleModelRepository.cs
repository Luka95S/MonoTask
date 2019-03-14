using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.VehicleRepository.Common
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetVehiclesModelAsync();
        Task<IVehicleModel> GetVehicleModelAsync(Guid id);
        Task<int> AddVehicleModelToSelectionAsync(IVehicleModel vehicleModel);
        Task<int> RemoveVehicleModelFromSelectionAsync(Guid id);
        Task<int> UpdateVehicleModelFromSelectionAsync(IVehicleModel vehicleModel);
    }
}
