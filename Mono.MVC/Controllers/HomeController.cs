using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Models;
using Mono.Services.Common;

namespace Mono.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleService vehicleService;

        public HomeController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Vehicles()
        {
            return View(await vehicleService.GetAllVehiclesAsync());
        }
    }
}
