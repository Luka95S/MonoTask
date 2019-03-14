using Mono.Models.Common;
using System;

namespace Mono.Models
{
    public class VehicleModel : IVehicleModel
    {
        public Guid Id { get; set; }
        public Guid MakeId{ get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}