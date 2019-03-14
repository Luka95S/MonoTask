using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mono.Models.Common;

namespace Mono.VehicleRepository.Common
{
    public interface IVehicleRepository
    {
        #region Methods

        Task<IEnumerable<IVehicleMake>> GetVehiclesAsync();
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);
        Task<int> AddVehicleMakeToSelectionAsync(IVehicleMake vehicleMake);
        Task<int> RemoveVehicleFromSelectionAsync(Guid id);
        Task<int> UpdateVehicleFromSelectionAsync(IVehicleMake vehicleMake);


        #endregion Methods
    }
}
