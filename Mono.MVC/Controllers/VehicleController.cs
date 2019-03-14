using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono.Models.Common;
using Mono.MVC.Models;
using Mono.Services.Common;

namespace Mono.MVC.Controllers
{
    [Route("vehicles")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        //vehicles
        [HttpGet("vehicles", Name = "get-vehicles")]
        public async Task<IActionResult> Vehicles([FromQuery(Name = "message")]string message)
        {
            ViewBag.Message = message;
            var response = mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vehicleService.GetAllVehiclesAsync());
            return View(response);
        }

        [HttpGet("vehicles/add-vehicle", Name = "add-vehicle")]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost("vehicles/add-vehicle", Name = "post-vehicle")]
        public async Task<IActionResult> AddVehicle([FromForm]VehicleMakeViewModel model)
        {
            model.Id = Guid.NewGuid();
            await vehicleService.AddVehiclesAsync(mapper.Map<IVehicleMake>(model));
            return Redirect(Url.RouteUrl("get-vehicles"));      
        }

        [HttpGet("vehicles/edit", Name = "edit-vehicle")]
        public async Task<IActionResult> EditVehicle([FromQuery(Name ="id")]Guid id)
        {
            var vehicle = await vehicleService.GetVehicleMakeAsync(id);
            return View(mapper.Map<VehicleMakeViewModel>(vehicle));
        }

        [HttpPost("vehicles/edit", Name = "edit-post-vehicle")]
        public async Task<IActionResult> EditVehicle([FromForm]VehicleMakeViewModel model ,[FromQuery(Name="id")]Guid id)
        {
            var result = await vehicleService.UpdateVehicleAsync(mapper.Map<IVehicleMake>(model),id);
            if (result == 1) {
                return Redirect(Url.RouteUrl("get-vehicles"));
            }
            return Redirect(Url.RouteUrl("edit-vehicle"));

        }
        [HttpGet("vehicles/delete", Name = "delete-vehicle")]
        public async Task<IActionResult> DeleteVehicle([FromQuery(Name = "id")]Guid id)
        {
            var result = await vehicleService.RemoveVehicleAsync(id);
            if (result == 1)
            {
                return Redirect(Url.RouteUrl("get-vehicles", new { message = "Delete success" }));
            }
            return Redirect(Url.RouteUrl("get-vehicles",new { message = "Delete failed" }));
        }
    }
}