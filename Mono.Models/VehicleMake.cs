using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models.Common;

namespace Mono.Models
{
    public class VehicleMake : IVehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
    }
}
