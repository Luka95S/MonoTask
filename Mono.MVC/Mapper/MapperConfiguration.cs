using AutoMapper;
using Mono.Models;
using Mono.Models.Common;
using Mono.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono.MVC.Mapper
{
    public class MapperConfiguration : Profile
    {
        public void Mapping()
        {
            CreateMap<IVehicle, VehicleMake>().ReverseMap();
            CreateMap<IVehicle, VehicleModel>().ReverseMap();
            CreateMap<IVehicle, VehicleMakeViewModel>().ReverseMap();
        }
    }
}
