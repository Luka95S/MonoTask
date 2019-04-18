using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Mono.DAL;
using Mono.VehicleRepository.Common;
using Mono.Models.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.DAL.DatabaseModels;
using Mono.Common;

namespace Mono.VehicleRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        /// <summary>
        /// Gets generic repository
        /// </summary>
        private IGenericRepository genericRepository { get; set; }

        /// <summary>
        /// Gets AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Inicialize instance of VehicleMakeRepository
        /// </summary>
        /// <param name="genericRepository"></param>
        /// <param name="mapper"></param>
        public VehicleRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets VehicleMakes that match passed parameter of filter.SearchBy 
        /// and gets all other parameters for filtering, pagin, sorting that match filter prop.
        /// Returns VehicleMake
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<IVehicleMake> GetVehicles(IFilter filter, IPaging paging, ISorting sort, IEmbedCollection embed)
        {
            if (filter.SearchBy != null)
            {
                paging = paging == null ? new Paging() : paging;
                sort = sort == null ? new Sorting(): sort;
                var vehicles = embed?.Embed != null ? genericRepository.GetWhereQuery<VehicleMakeModel>().Where(x => x.Name.StartsWith(filter.SearchBy) == true).Include(embed.Embed) : genericRepository.GetWhereQuery<VehicleMakeModel>().Where(x => x.Name.StartsWith(filter.SearchBy) == true);
                var count = vehicles.Count();
                if (vehicles == null)
                {
                    return null;
                }
                switch (sort.SortBy)
                {
                    //name, abrv
                    case "abrv":  // sort by Abrv and asc or desc(depend of SortOrder value)
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Abrv) : vehicles.OrderByDescending(s => s.Abrv);
                        break;
                    case "name":  // sort by Name and asc or desc(depend of SortOrder value)
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Name) : vehicles.OrderByDescending(s => s.Name);
                        break;
                    default:
                        vehicles = vehicles.OrderBy(s => s.Name);
                        break;
                }
                //takes specifit amount of items in vehicle depending on filter prop
                vehicles = vehicles.Skip(paging.Skip).Take(paging.NumberOfItems);

                var response = new VehicleMake
                {
                    VehicleMakes = mapper.Map<IEnumerable<IVehicleMake>>(vehicles),
                    TotalItemsCount = count
                };
                return Task.FromResult(mapper.Map<IVehicleMake>(response));
            }
            else
            {
                paging = paging == null ? new Paging() : paging;
                sort = sort == null ? new Sorting() : sort;
                var vehicles = embed.Embed != null ? genericRepository.GetWhereQuery<VehicleMakeModel>().Include(embed.Embed) : genericRepository.GetWhereQuery<VehicleMakeModel>();
                var count = vehicles.Count();
                if (vehicles == null)
                {
                    return null;
                }
                switch (sort.SortBy)
                {
                    //name, abrv
                    case "abrv":  // sort by Abrv and asc or desc(depend of SortOrder value)
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Abrv) : vehicles.OrderByDescending(s => s.Abrv);
                        break;
                    case "name":  // sort by Name and asc or desc(depend of SortOrder value)
                        vehicles = sort.SortOrder == "asc" ? vehicles.OrderBy(s => s.Name) : vehicles.OrderByDescending(s => s.Name);
                        break;
                    default:
                        vehicles = vehicles.OrderBy(s => s.Name);
                        break;
                }
                //takes specifit amount of items in vehicle depending on filter prop
                vehicles = vehicles.Skip(paging.Skip).Take(paging.NumberOfItems);
                var response = new VehicleMake
                {
                    VehicleMakes = mapper.Map<IEnumerable<IVehicleMake>>(vehicles),
                    TotalItemsCount = count
                };
                return Task.FromResult(mapper.Map<IVehicleMake>(response));
            }
        }

        /// <summary>
        /// Gets VehicleMake with id match of passed id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            return mapper.Map<IVehicleMake>(await genericRepository.GetAsync<VehicleMakeModel>(id));
        }

        /// <summary>
        /// Gets VehicleMake model by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>VehicleMake model</returns>
        public Task<IVehicleMake> GetVehicleMakeByName(string name)
        {
            return Task.FromResult(mapper.Map<IVehicleMake>(genericRepository.GetWhereQuery<VehicleMakeModel>().AsNoTracking().FirstOrDefault(x => x.Name == name)));
        }

        /// <summary>
        /// Adds VehicleMake
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns>integer - 1 success aand 0 for fail</returns>
        public async Task<int> AddVehicleMakeToSelectionAsync(IVehicleMake vehicleMake)
        {
            return await genericRepository.AddAsync(mapper.Map<VehicleMakeModel>(vehicleMake));
        }

        /// <summary>
        /// Removes VehicleMake
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> RemoveVehicleFromSelectionAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleMakeModel>(id);
        }

        /// <summary>
        /// Updates VehicleMake
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns></returns>
        public async Task<int> UpdateVehicleFromSelectionAsync(IVehicleMake vehicleMake)
        {
            return await genericRepository.UpdateAsync(mapper.Map<VehicleMakeModel>(vehicleMake));
        }
    }
}
