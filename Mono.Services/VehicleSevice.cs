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

        public async Task<IEnumerable<IVehicle>> GetAllVehiclesAsync()
        {
            return await vehicleRepository.GetVehiclesAsync();
        }
    }
}
