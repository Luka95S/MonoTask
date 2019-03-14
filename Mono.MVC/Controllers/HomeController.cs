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
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        [HttpGet("",Name="index")]
        //home
        public IActionResult Index()
        {
            return View();
        }


    }
}
