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
        Task<int> AddVehicleToSelectionAsync(int makeId);
        Task<int> RemoveVehicleFromSelectionAsync(int makeId);
        

        #endregion Methods
    }
}
