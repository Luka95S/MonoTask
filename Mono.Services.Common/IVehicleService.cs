using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono.Services.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<IVehicleMake>> GetAllVehiclesAsync();
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);
        Task<int> AddVehiclesAsync(IVehicleMake vehicle);
        Task<int> RemoveVehicleAsync(Guid id);
        Task<int> UpdateVehicleAsync(IVehicleMake vehicle, Guid id );

    }
}
