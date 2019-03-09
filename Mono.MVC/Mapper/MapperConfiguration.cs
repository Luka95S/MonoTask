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
            CreateMap<VehicleMakeViewModel, IVehicle>().ReverseMap();
               // .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
               // .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
               // .ForMember(d => d.Abrv, o => o.MapFrom(s => s.Abrv));
        }
    }
}
