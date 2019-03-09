using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Mono.DBContext;
using Mono.VehicleRepository.Common;
using Mono.Models.Common;
using AutoMapper;

namespace Mono.VehicleRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        public IGenericRepository GenericRpContext { get; private set; }

        public VehicleRepository(IGenericRepository GenericRpContext)
        {
            this.GenericRpContext = GenericRpContext;
        }

        public async Task<IEnumerable<IVehicle>> GetVehiclesAsync()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicle>>(await GenericRpContext.GetAll<VehicleMake>());
        }

        public async Task<int> AddVehicleMakeToSelectionAsync(IVehicle vehicleMake)
        {
            return await GenericRpContext.Add<IVehicle>(AutoMapper.Mapper.Map<VehicleMake>(vehicleMake));
        }

        public async Task<int> RemoveVehicleFromSelectionAsync(IVehicle vehicleMake)
        {
            return await GenericRpContext.Delete<IVehicle>(AutoMapper.Mapper.Map<VehicleMake>(vehicleMake));
        }
    }
}
