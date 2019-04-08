using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mono.Models
{
    /// <summary>
    /// VehicleModel model as data transfer object used for communication within project.
    /// Prop: Guid Id, Guid VehicleMakeId, string Name, string Abrv and IVehicleMake of VehicleMakes
    /// </summary>
    public class VehicleModel : IVehicleModel
    {
        /// <summary>
        /// Gets or sets Id value of type Guid
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakeId value of type Guid
        /// </summary>
        [Required]
        public Guid VehicleMakeId { get;set; }

        /// <summary>
        /// Gets or sets Name value of type string
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv value of type string
        /// </summary>
        [Required]
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakes value of type IVehicleMake  
        /// </summary>
        public IVehicleMake VehicleMakes { get; set; }
    }
}