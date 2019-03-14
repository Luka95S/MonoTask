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
    [Route("")]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
        }

        //vehicles-model
        [HttpGet("vehicles-model", Name = "get-vehicles-model")]
        public async Task<IActionResult> VehiclesModel([FromQuery(Name = "message")]string message)
        {
            ViewBag.Message = message;
            var response = mapper.Map<IEnumerable<VehicleModelViewModel>>(await vehicleModelService.GetAllVehiclesAsync());
            return View(response);
        }

        [HttpGet("vehicles-model/add-vehicle-model", Name = "add-vehicle-model")]
        public IActionResult AddVehicleModel()
        {
            return View();
        }

        [HttpPost("vehicles-model/add-vehicle-model", Name = "post-vehicle-model")]
        public async Task<IActionResult> AddVehicleModel([FromForm]VehicleModelViewModel model)
        {
            model.Id = Guid.NewGuid();
            await vehicleModelService.AddVehiclesModelAsync(mapper.Map<IVehicleModel>(model));
            return Redirect(Url.RouteUrl("get-vehicles-model"));
        }

        [HttpGet("vehicle-model/edit", Name = "edit-vehicle-model")]
        public async Task<IActionResult> EditVehicleModel([FromQuery(Name = "id")]Guid id)
        {
            var vehicleModel = await vehicleModelService.GetVehicleModelAsync(id);
            return View(mapper.Map<VehicleModelViewModel>(vehicleModel));
        }

        [HttpPost("vehicle-model/edit", Name = "edit-vehicle-model-post")]
        public async Task<IActionResult> EditVehicleModel([FromForm]VehicleModelViewModel model, [FromQuery(Name = "id")]Guid id)
        {
            var result = await vehicleModelService.UpdateVehicleModelAsync(mapper.Map<IVehicleModel>(model), id);
            if (result == 1)
            {
                return Redirect(Url.RouteUrl("get-vehicles-model"));
            }
            return Redirect(Url.RouteUrl("edit-vehicle-model"));
        }
        
        [HttpGet("vehicle-model/delete", Name = "delete-vehicle-model")]
        public async Task<IActionResult> DeleteVehicleModel([FromQuery(Name = "id")]Guid id)
        {
            var result = await vehicleModelService.RemoveVehicleModelAsync(id);
            if (result ==1)
            {
                return Redirect(Url.RouteUrl("get-vehicles-model", new { message = "Delete success" }));
            }
            return Redirect(Url.RouteUrl("get-vehicles-model", new { message = "Delete failed" }));
        }
    }
}