using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mono.DAL;
using Mono.Models;
using Mono.Models.Common;
using System.Linq;
using Mono.VehicleRepository.Common;
using Microsoft.EntityFrameworkCore;
using Mono.DAL.DatabaseModels;
using Mono.Common;
using System.Collections;
using System.Reflection;

namespace Mono.VehicleRepository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        /// <summary>
        /// Gets generic repository
        /// </summary>
        private readonly IGenericRepository genericRepository; 

        /// <summary>
        /// Gets AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Inicialize instance of VehicleModelRepository
        /// </summary>
        /// <param name="genericRepository"></param>
        /// <param name="mapper"></param>
        public VehicleModelRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets VehicleModels that match passed parameter of filter.SearchBy 
        /// and all other parameters for filtering, pagin, sorting that match filter prop.
        /// Returns IEnumerable of VehicleModel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<IVehicleModel> GetVehiclesModel(IFilter filter, IPaging paging, ISorting sort, IEmbedCollection embed)
        {
            if (filter.SearchBy != null)
            {
                var vehicles = embed.Embed != null ? genericRepository.GetWhereQuery<VehicleModelModel>().Where(x => x.VehicleMakes.Name.StartsWith(filter.SearchBy) == true).Include(embed.Embed).AsNoTracking() : genericRepository.GetWhereQuery<VehicleModelModel>().Where(x => x.VehicleMakes.Name.StartsWith(filter.SearchBy) == true).AsNoTracking();
                var count = vehicles.Count();
                if (vehicles == null)
                {
                    return null;
                }
                switch (sort.SortBy)
                {
                    //name, abrv
                    // sort by Abrv and asc or desc(depend of SortOrder value)
                    case "abrv":  
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Abrv) : vehicles.OrderByDescending(s => s.Abrv);
                        break;
                    // sort by Name and asc or desc(depend of SortOrder value)
                    case "name":  
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Name) : vehicles.OrderByDescending(s => s.Name);
                        break;
                }
                //takes specifit amount of items in vehicle depending on filter prop
                vehicles = vehicles.Skip(paging.Skip).Take(paging.NumberOfItems);

                var response = new VehicleModel
                {
                    VehicleModels = mapper.Map<IEnumerable<IVehicleModel>>(vehicles),
                    TotalItemsCount = count
                };
                return Task.FromResult(mapper.Map<IVehicleModel>(response));
            }
            else
            {
                var vehicles = embed.Embed != null ? genericRepository.GetWhereQuery<VehicleModelModel>().Include(embed.Embed).AsNoTracking() : genericRepository.GetWhereQuery<VehicleModelModel>().AsNoTracking();
                var count = vehicles.Count();

                if (vehicles == null)
                {
                    return null;
                }
                switch (sort.SortBy)
                {
                    //name, abrv
                    // sort by Abrv and asc or desc(depend of SortOrder value)
                    case "abrv":  
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Abrv) : vehicles.OrderByDescending(s => s.Abrv);
                        break;
                    // sort by Name and asc or desc(depend of SortOrder value)
                    case "name": 
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Name) : vehicles.OrderByDescending(s => s.Name);
                        break;
                }
                //takes specifit amount of items in vehicle depending on filter prop
                vehicles = vehicles.Skip(paging.Skip).Take(paging.NumberOfItems);
                var response = new VehicleModel
                {
                    VehicleModels = mapper.Map<IEnumerable<VehicleModel>>(vehicles),
                    TotalItemsCount = count
                };
                return Task.FromResult(mapper.Map<IVehicleModel>(response)); ;
            }



        }

        /// <summary>
        /// Gets VehicleModel with id match of passed id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IVehicleModel> GetVehicleModel(Guid id)
        {

            return Task.FromResult(mapper.Map<IVehicleModel>(genericRepository.GetWhereQuery<VehicleModelModel>().Include("VehicleMakes").FirstOrDefault(v => v.Id == id)));
        }

        /// <summary>
        /// Adds VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        public async Task<int> AddVehicleModelToSelectionAsync(IVehicleModel vehicleModel)
        {
            return await genericRepository.AddAsync(mapper.Map<VehicleModelModel>(vehicleModel));
        }

        /// <summary>
        /// Removes VehicleModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        public async Task<int> RemoveVehicleModelFromSelectionAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModelModel>(id);
        }

        /// <summary>
        /// Updates VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        public async Task<int> UpdateVehicleModelFromSelectionAsync(IVehicleModel vehicleModel)
        {
            return await genericRepository.UpdateAsync(mapper.Map<VehicleModelModel>(vehicleModel));
        }
    } 
}
