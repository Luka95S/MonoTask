using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Mono.DBContext;
using Mono.VehicleRepository.Common;
using Mono.Models.Common;
using AutoMapper;

namespace Mono.VehicleRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        public IGenericRepository genericRepository { get; private set; }

        private readonly IMapper mapper;
        public VehicleRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehiclesAsync()
        {
            return mapper.Map<IEnumerable<IVehicleMake>>(await genericRepository.GetAll<VehicleMake>());
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            return mapper.Map<IVehicleMake>(await genericRepository.Get<VehicleMake>(id));
        }

        public async Task<int> AddVehicleMakeToSelectionAsync(IVehicleMake vehicleMake)
        {
            return await genericRepository.Add<IVehicleMake>(mapper.Map<VehicleMake>(vehicleMake));
        }

        public async Task<int> RemoveVehicleFromSelectionAsync(Guid id)
        {
            return await genericRepository.Delete<VehicleMake>(id);
        }

        public async Task<int> UpdateVehicleFromSelectionAsync(IVehicleMake vehicleMake)
        {
            return await genericRepository.Update<VehicleMake>(mapper.Map<VehicleMake>(vehicleMake));
        }

    }
}
