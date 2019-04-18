using System;
using System.Collections.Generic;

namespace Mono.Models.Common
{
    public interface IVehicleMake
    {
        /// <summary>
        /// VehicleMake model as data transfer object used for communication within project.
        /// Prop: Guid Id, string Name, string Abrv and IEnumerable of type IVehicleModel for VehicleModels
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets Abrv
        /// </summary>
        string Abrv { get; set; }

        /// <summary>
        /// Gets or sets list of VehicleModels 
        /// </summary>get;
        IEnumerable<IVehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// Gets or sets VehicleMakes
        /// </summary>
        IEnumerable<IVehicleMake> VehicleMakes { get; set; }

        /// <summary>
        /// Gets or sets total number of items
        /// </summary>
        int TotalItemsCount { get; set; }

    }
}