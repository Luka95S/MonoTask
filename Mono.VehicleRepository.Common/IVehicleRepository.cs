using System;
using System.Collections.Generic;
using System.Text;
using Mono.Models.Common;

namespace Mono.VehicleRepository.Common
{
    public interface IVehicleRepository
    {
        #region Methods

        List<IVehicle> GetVehicles();
        bool AddVehicleToSelection(int makeId);
        bool RemoveVehicleFromSelection(int makeId);

        #endregion Methods
    }
}
