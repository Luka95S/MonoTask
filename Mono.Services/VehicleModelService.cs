﻿using Mono.Common;
using Mono.Models;
using Mono.Models.Common;
using Mono.Services.Common;
using Mono.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        /// <summary>
        /// Gets VehicleModel repository
        /// </summary>
        public IVehicleModelRepository vehicleModelRepository { get; private set; }

        /// <summary>
        /// Inicialize instance of VehicleModelService
        /// </summary>
        /// <param name="vehicleModelRepository"></param>
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }

        /// <summary>
        /// Gets all VehicleModels that match to filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<IVehicleModel> GetAllVehicles(IFilter filter, IPaging paging, ISorting sort, IEmbedCollection embed)
        {
            return vehicleModelRepository.GetVehiclesModel(filter, paging, sort, embed);
        }

        /// <summary>
        /// Gets VehicleModel by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IVehicleModel> GetVehicleModel(Guid id)
        {
            return vehicleModelRepository.GetVehicleModel(id);
        }
        
        /// <summary>
        /// Adds VehicleModel to database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<int> AddVehiclesModelAsync(IVehicleModel vehicle)
        {
            return await vehicleModelRepository.AddVehicleModelToSelectionAsync(vehicle);
        }

        /// <summary>
        /// Removes VehicleModel by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> RemoveVehicleModelAsync(Guid id)
        {
            return await vehicleModelRepository.RemoveVehicleModelFromSelectionAsync(id);
        }

        /// <summary>
        /// Updates VehicleModel
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<int> UpdateVehicleModelAsync(IVehicleModel vehicle)
        {
            return await vehicleModelRepository.UpdateVehicleModelFromSelectionAsync(vehicle);
        }
    }
}
