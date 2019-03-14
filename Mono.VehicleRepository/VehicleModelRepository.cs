using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mono.DBContext;
using Mono.Models;
using Mono.Models.Common;
using System.Linq;
using Mono.VehicleRepository.Common;

namespace Mono.VehicleRepository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IGenericRepository genericRepository;

        private readonly IMapper mapper;
        public VehicleModelRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehiclesModelAsync()
        {
            return mapper.Map<IEnumerable<IVehicleModel>>(await genericRepository.GetAll<VehicleModel>());
        }

        public async Task<IVehicleModel> GetVehicleModelAsync( Guid id)
        {     
            return mapper.Map<IVehicleModel>(await genericRepository.Get<VehicleModel>(id));
        }

        public async Task<int> AddVehicleModelToSelectionAsync(IVehicleModel vehicleModel)
        {
            return await genericRepository.Add<IVehicleModel>(mapper.Map<VehicleModel>(vehicleModel));
        }

        public async Task<int> RemoveVehicleModelFromSelectionAsync(Guid id)
        {
            return await genericRepository.Delete<VehicleModel>(id);
        }

        public async Task<int> UpdateVehicleModelFromSelectionAsync(IVehicleModel vehicleModel)
        {
            return await genericRepository.Update<IVehicleModel>(mapper.Map<VehicleModel>(vehicleModel));
        }

        //public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsWithArgumentAsync(int page , int numberOfItems,string orderBy)
        //{
        //    genericRepository.GetWhereQuery<IVehicleModel>().Skip(page).Take(numberOfItems).OrderBy(x => x.Name == orderBy);
        //}
        //napravi jos update metodu i napravi get samo single objekta - pitanje: metoda za dohvaćanje po određenom 
        // argumentu GetWhere -> kako ju napisati i njezin tok kako ide 
    }
}
