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
    internal class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModelViewModel>()
                .ForMember(d => d.VehicleName, o => o.Ignore());
            CreateMap<VehicleModelViewModel, IVehicleModel>();

            CreateMap<VehicleMakeViewModel, IVehicleMake>()
               // .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Abrv, o => o.MapFrom(s => s.Abrv))
                .ReverseMap();
        }
    }
}
