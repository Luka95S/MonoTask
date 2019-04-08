using Mono.Models;
using Mono.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono.MVC.Models
{
    /// <summary>
    /// Data view model for represetating model in view.
    /// Prop: IEnumerable of VehicleMake type AllVehicles, bool Next, bool Previous, int TotalPageCount
    /// </summary>
    public class AllVehiclesViewModel
    {
        /// <summary>
        /// Gets or sets AllVehicles
        /// </summary>
        public IEnumerable<VehicleMake> AllVehicles { get; set; }

        /// <summary>
        /// Gets or sets Next
        /// </summary>
        public bool Next { get; set; }

        /// <summary>
        /// Gets or sets Previous
        /// </summary>
        public bool Previous { get; set; }

        /// <summary>
        /// Gets or sets TotalPageCount
        /// </summary>
        public int TotalPageCount { get; set; } 
    }
}
