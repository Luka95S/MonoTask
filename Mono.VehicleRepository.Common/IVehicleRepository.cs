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
        
        Task<IEnumerable<IVehicle>> GetVehiclesAsync();
        Task<int> AddVehicleMakeToSelectionAsync(IVehicle vehicleMake);
        Task<int> RemoveVehicleFromSelectionAsync(IVehicle vehicleMake);
        

        #endregion Methods
    }
}
