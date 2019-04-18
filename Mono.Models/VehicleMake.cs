using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models.Common;

namespace Mono.Models
{
    /// <summary>
    /// VehicleMake model as data transfer object used for communication within project.
    /// Prop: Guid Id, string Name, string Abrv and IEnumerable of type IVehicleModel for VehicleModels
    /// </summary>
    public class VehicleMake : IVehicleMake
    {
        /// <summary>
        /// Gets or sets VehicleMake identifier
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv
        /// </summary>
        [Required]
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets list of VehicleModels 
        /// </summary>
        public IEnumerable<IVehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakes
        /// </summary>
        public IEnumerable<IVehicleMake> VehicleMakes { get; set; }

        /// <summary>
        /// Gets or sets total number of items
        /// </summary>
        public int TotalItemsCount { get; set; }

    }


}
