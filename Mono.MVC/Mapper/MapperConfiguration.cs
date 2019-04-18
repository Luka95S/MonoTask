using AutoMapper;
using Mono.DAL.DatabaseModels;
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
            #region DataBase Objects
            CreateMap<VehicleModelModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModelModel>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMakeModel>().ReverseMap();
            #endregion
            #region Data Transfer Objects
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            #endregion
            #region Data View Objects
            CreateMap<IVehicleModel, VehicleModelViewModel>();
            CreateMap<VehicleModelViewModel, IVehicleModel>();
            CreateMap<VehicleMakeViewModel, IVehicleMake>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Abrv, o => o.MapFrom(s => s.Abrv))
                .ReverseMap();
            #endregion
        }
    }
}
