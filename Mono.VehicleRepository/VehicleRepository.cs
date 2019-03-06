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
    class VehicleRepository : IVehicleRepository
    {
        public IVehicleRepository Context { get; private set; }

        public VehicleRepository(IVehicleRepository context)
        {
            this.Context = context;
        }
        public List<VehicleModel> GetVehicleModels()
        {
            VehicleDBContext vehicleDBContext = new VehicleDBContext();
            return vehicleDBContext.Vehicles.ToList();
        }

        public List<IVehicle> GetVehicles()
        {
            return Context.GetVehicles();
        }

        public bool AddVehicleToSelection(int makeId)
        {
            return Context.AddVehicleToSelection(makeId);
        }

        public bool RemoveVehicleFromSelection(int makeId)
        {
            return Context.RemoveVehicleFromSelection(makeId);
        }

    }
}
