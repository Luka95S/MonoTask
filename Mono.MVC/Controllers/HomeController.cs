using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono.Models;
using Mono.MVC.Models;
using Mono.Services.Common;

namespace Mono.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Vehicles()
        {
            var alo = await vehicleService.GetAllVehiclesAsync();
            return View(mapper.Map<VehicleMake>(alo));
        }
    }
}
