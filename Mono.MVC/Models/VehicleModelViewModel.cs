using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono.MVC.Models
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string VehicleName { get; set; }
    }
}
