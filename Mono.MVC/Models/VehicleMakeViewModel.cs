using Mono.Models;
using Mono.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mono.MVC.Models
{
    /// <summary>
    /// Data view model for represetating VehicleMake model in view.
    /// Prop: Guid Id, string Name, string Abrv, IEnumerable of VehicleMake in AllVehicleMakes, bool Next, bool Previous, int TotalPageCount
    /// </summary>
    public class VehicleMakeViewModel
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
        [StringLength(35)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets AllVehicleMakes
        /// </summary>
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }
    }
}
