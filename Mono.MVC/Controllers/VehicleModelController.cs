using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono.Common;
using Mono.Models;
using Mono.Models.Common;
using Mono.MVC.Models;
using Mono.Services.Common;

namespace Mono.MVC.Controllers
{
    [Route("")]
    public class VehicleModelController : Controller
    {
        /// <summary>
        /// Gets the Vehicle Model service
        /// </summary>
        private readonly IVehicleModelService vehicleModelService;

        /// <summary>
        /// Gets AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Gets Vehicle Make service
        /// </summary>
        private readonly IVehicleService vehicleService;

        /// <summary>
        /// Initializes a new instance of the VehicleModelController class
        /// </summary>
        /// <param name="vehicleModelService"></param>
        /// <param name="mapper"></param>
        /// <param name="vehicleService"></param>
        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper, IVehicleService vehicleService)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
            this.vehicleService = vehicleService;
        }

        /// <summary>
        /// HttpGet VehicleModel metod. Gets parameters from query, sets them to filter model and sends filter to service.
        /// Sets value for next and previous button - disable = true/false.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="page"></param>
        /// <param name="sortOrder"></param>
        /// <param name="sortBy"></param>
        /// <param name="searchBy"></param>
        /// <returns></returns>
        [HttpGet("vehicles-model", Name = "get-vehicles-model")]
        public IActionResult VehiclesModel([FromQuery(Name = "message")] string message, [FromQuery(Name = "page")]int page = 1, [FromQuery(Name = "sortOrder")] string sortOrder = "asc", [FromQuery(Name = "sortBy")] string sortBy = "name", [FromQuery(Name = "searchby")] string searchBy = "")
        {
            var filter = new Filter();
            var sort = new Sorting();
            var paging = new Paging();
            var embed = new EmbedCollection("VehicleMakes");
            paging.Page = page;
            sort.SortOrder = sortOrder;
            sort.SortBy = sortBy;
            searchBy = searchBy == null ? "" : searchBy;
            filter.SearchBy = searchBy;
            var viewModel = new VehicleModelViewModel();
            IVehicleModel vehicles = mapper.Map<VehicleModel>(vehicleModelService.GetAllVehicles(filter, paging, sort, embed).Result);
            viewModel.AllVehicleModels = mapper.Map<IEnumerable<VehicleModel>>(vehicles.VehicleModels);
            ViewBag.Previous = paging.Skip == 0 ? false : true;
            ViewBag.Next = vehicles.TotalItemsCount - paging.Skip - paging.NumberOfItems <= 0 ? false : true;
            if (viewModel.AllVehicleModels != null)
            {
                ViewBag.Message = vehicles.TotalItemsCount == 0 ? "No search items found! Try again" : message;
                return View(viewModel);
            }
            ViewBag.Message = "There are no VehicleModels in database. Add them!";
            return View(viewModel);
        }

        /// <summary>
        /// HttpGet AddVehicleModel metod. Gets the view AddVehicleModel.cshtml with http form for adding vehicle.
        /// Has ViewBag.Message that get's from query if user enters VehicleMake that doesn't exist in database.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet("vehicles-model/add-vehicle-model", Name = "add-vehicle-model")]
        public IActionResult AddVehicleModel([FromQuery(Name = "message")] string message)
        {
            ViewBag.Message = message;
            return View();
        }

        /// <summary>
        /// HttpPost AddVehicle metod.Take VehicleMakeViewModel adds new Guid to model.Id.
        /// Gets VehicleMake model that coresponds VehicleModel.
        /// Map to type of IVehicleMake(DTO) and call service method for adding.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirect to VehicleModel metod with redirect</returns>
        [HttpPost("vehicles-model/add-vehicle-model", Name = "post-vehicle-model")]
        public async Task<IActionResult> AddVehicleModel([FromForm]VehicleModelViewModel model)
        {
            model.Id = Guid.NewGuid();
            var vehicleMake = mapper.Map<VehicleMake>(vehicleService.GetVehicleMakeByName(model.VehicleName).Result);
            if (vehicleMake != null)
            { 
                try
                {
                    model.VehicleMakes = mapper.Map<VehicleMake>(await vehicleService.GetVehicleMakeAsync(vehicleMake.Id));
                    if (model.VehicleMakes != null)
                    {
                        await vehicleModelService.AddVehiclesModelAsync(mapper.Map<IVehicleModel>(model));
                        return Redirect(Url.RouteUrl("get-vehicles-model"));
                    }
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                        Console.WriteLine("Exception source: {0}", e.Source);
                }
            }
            return Redirect(Url.RouteUrl("add-vehicle-model", new { message = "Vehicle Make doesn't exist in database. Add it to database then try to add Vehicle Model or select existing Vehicle Make from dropdown" })   );
         }

        /// <summary>
        /// HttpGet metod. Gets from urlroute id, sends to service metod id (as parameter)
        /// to get model with that id and returns it to view for editing.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewModel</returns>
        [HttpGet("vehicle-model/edit", Name = "edit-vehicle-model")]
        public IActionResult EditVehicleModel([FromQuery(Name = "id")]Guid id)
        {
            var vehicleModel = vehicleModelService.GetVehicleModel(id).Result;
            return vehicleModel != null ? View(mapper.Map<VehicleModelViewModel>(vehicleModel)) : View();
        }

        /// <summary>
        /// HttpPost metod. Take VehicleModelViewModel from form.
        /// Sends it to service to make an update of model on database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>For succes returns Vehicle metod and for fail returns edit view</returns>
        [HttpPost("vehicle-model/edit", Name = "edit-vehicle-model-post")]
        public async Task<IActionResult> EditVehicleModel([FromForm]VehicleModelViewModel model)
        { 
            var vehiclem = mapper.Map<VehicleMake>(vehicleService.GetVehicleMakeByName(model.VehicleName).Result);
            model.VehicleMakes = vehiclem;
            var vehicle = mapper.Map<IVehicleModel>(model);
            var result = await vehicleModelService.UpdateVehicleModelAsync(vehicle);
            var succSave = result == 0 ? false : true;
            return result == 2 ? Redirect(Url.RouteUrl("get-vehicles-model")) : Redirect(Url.RouteUrl("edit-vehicle-model"));
        }

        /// <summary>
        /// HttpGet DeleteVehicleModel metod. Take id parameter from url route and removes model that match that model.id
        /// in database by calling service method and passing argument(id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("vehicle-model/delete", Name = "delete-vehicle-model")]
        public async Task<IActionResult> DeleteVehicleModel([FromQuery(Name = "id")]Guid id)
        {
            if (id != Guid.Empty)
            { 
                try
                {
                    var result = await vehicleModelService.RemoveVehicleModelAsync(id);
                    if (result == 1)
                    {
                        return Redirect(Url.RouteUrl("get-vehicles-model", new { message = "Delete success" }));
                    }
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                        Console.WriteLine("Exception source: {0}", e.Source);
                }
            }
            return Redirect(Url.RouteUrl("get-vehicles-model", new { message = "Delete failed. Try again" }));
        }

        /// <summary>
        /// HttpGet GetAllVehicles metod for dropdown menu
        /// </summary>
        /// <param name="query"></param>
        /// <returns>JsonResult list of VehicleMake</returns>
        [HttpGet("vehicles/get-all-vehicles", Name = "get-vehicles-by-query")]
        public JsonResult GetAllVehicles(string query)
        {
            var filter = new Filter();
            filter.SearchBy = query;
            var vehicles = vehicleService.GetAllVehicles(filter, null, null, null).Result;
            return vehicles != null ? Json(vehicles.VehicleMakes) : null;
        }
    }
}