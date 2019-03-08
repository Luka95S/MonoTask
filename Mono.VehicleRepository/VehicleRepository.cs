using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Mono.DBContext;
using Mono.VehicleRepository.Common;
using Mono.Models.Common;

namespace CodeEFTest
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
            return await GenericRpContext.GetAll<IVehicle>();
        }

        public Task<int> AddVehicleToSelectionAsync(int makeId)
        {
            return await GenericRpContext.Add<IVehicle>();
        }

        public Task<int> RemoveVehicleFromSelectionAsync(int makeId)
        {
            throw new NotImplementedException();
        }
    }
}
