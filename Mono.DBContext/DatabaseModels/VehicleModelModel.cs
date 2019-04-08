using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mono.DAL.DatabaseModels
{
    ///<summary>
    /// VehicleModel model for database
    /// with prop: Guid Id, str Name, str Abrv and FK(VehicleMakes) 
    /// </summary>
    public class VehicleModelModel
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
        /// Gets or sets VehicleMakes value of type VehicleMakeModel
        /// It's also FK on VehicleMakeModel
        /// </summary>
        public VehicleMakeModel VehicleMakes { get; set; }

    }
}
