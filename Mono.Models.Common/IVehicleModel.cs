using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mono.Models;

namespace Mono.Models.Common
{
    public interface IVehicleModel
    {
        /// <summary>
        /// Gets or sets Id value of type Guid
        /// </summary>
        [Required]
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakeId value of type Guid
        /// </summary>
        [Required]
        Guid VehicleMakeId { get; set; }

        /// <summary>
        /// Gets or sets Name value of type string
        /// </summary>
        [Required]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv value of type string
        /// </summary>
        [Required]
        string Abrv { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakes value of type IVehicleMake  
        /// </summary>
        IVehicleMake VehicleMakes { get; set; }
    }
}
