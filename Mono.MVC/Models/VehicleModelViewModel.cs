using Mono.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mono.MVC.Models
{
    public class VehicleModelViewModel
    {
        /// <summary>
        /// Gets or sets VehicleModel identifier
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets VehicleMake Name
        /// </summary>
        [Required]
        public string VehicleName { get; set; }

        /// <summary>
        /// Gets or sets AllVehicleModels coresponding to VehicleMake
        /// </summary>
        public IEnumerable<VehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakes
        /// </summary>
        public VehicleMake VehicleMakes { get; set; }
    }
}
