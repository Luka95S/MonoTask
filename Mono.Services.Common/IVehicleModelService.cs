using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Services.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetAllVehiclesAsync();
        Task<IVehicleModel> GetVehicleModelAsync(Guid id);
        Task<int> AddVehiclesModelAsync(IVehicleModel vehicle);
        Task<int> RemoveVehicleModelAsync(Guid id);
        Task<int> UpdateVehicleModelAsync(IVehicleModel vehicle, Guid id);
    }
}
