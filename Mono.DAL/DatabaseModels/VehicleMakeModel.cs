using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mono.DAL.DatabaseModels
{
    ///<summary>
    /// VehicleMake model for database
    /// with prop: Guid Id, str Name, str Abrv and FK (List of VehicleModels)
    /// </summary>    
    public class VehicleMakeModel
    {
        /// <summary>
        /// Gets or sets Id value of type Guid
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name value of type string
        /// </summary>
        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv value of type string
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets VehicleModels value of type List of VehicleModelModel
        /// It's also FK on VehicleModelModel
        /// </summary>
        public List<VehicleModelModel> VehicleModels { get; set; }
    }
}
