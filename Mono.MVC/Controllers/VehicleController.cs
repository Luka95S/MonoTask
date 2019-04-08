using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    [Route("vehicles")]
    public class VehicleController : Controller
    {
        /// <summary>
        /// Gets the service
        /// </summary>
        private readonly IVehicleService vehicleService;

        /// <summary>
        /// Gets the AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the VehicleController class
        /// </summary>
        /// <param name="vehicleService"></param>
        /// <param name="mapper"></param>
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        /// <summary>
        /// HttpGet Vehicle metod. Gets parameters from query, sets them to filter model and sends filter to service.
        /// Sets value for next and previous button - disable = true/false.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="page"></param>
        /// <param name="sortOrder"></param>
        /// <param name="sortBy"></param>
        /// <param name="searchBy"></param>
        /// <returns>viewModel as parameter in View() - viewModel is list of VehicleMake models</returns>
        [HttpGet("vehicles", Name = "get-vehicles")]
        public IActionResult Vehicles([FromQuery(Name = "message")]string message, [FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "sortOrder")] string sortOrder = "asc", [FromQuery(Name = "sortBy")] string sortBy = "name", [FromQuery(Name = "searchBy")] string searchBy = "")
        {
            var filter = new Filter();
            filter.Page = page;
            filter.SortOrder = sortOrder;
            filter.SortBy = sortBy;
            searchBy = searchBy == null ? "" : searchBy;
            filter.SearchBy = searchBy;
            var viewModel = new VehicleMakeViewModel();
            viewModel.AllVehicleMakes = mapper.Map<IEnumerable<VehicleMake>>(vehicleService.GetAllVehicles(filter));
            if (viewModel.AllVehicleMakes != null)
            {
                viewModel.TotalPageCount = vehicleService.GetVehicleCount(filter.SearchBy);
                viewModel.Previous = filter.Skip == 0 ? false : true;
                viewModel.Next = viewModel.TotalPageCount - filter.Skip - filter.NumberOfItems <= 0 || viewModel.AllVehicleMakes.Count() - filter.NumberOfItems < 0 ? false : true;
                ViewBag.Message = viewModel.AllVehicleMakes.Count() == 0 ? "No search items found! Try again" : message;
                return View(viewModel);
            }
            ViewBag.Message = "There are no VehicleMake models in database. Add them!";
            return View(viewModel);
        }

        /// <summary>
        /// HttpGet AddVehicle metod. Gets the view AddVehicle.cshtml with http form for adding vehicle
        /// </summary>
        /// <returns>View()</returns>
        [HttpGet("vehicles/add-vehicle", Name = "add-vehicle")]
        public IActionResult AddVehicle([FromQuery(Name = "message")]string message)
        {
            ViewBag.Message = message;
            return View();
        }

        /// <summary>
        /// HttpPost AddVehicle metod.Take VehicleMakeViewModel adds new Guid to model.Id.
        /// Map to type of IVehicleMake(DTO) and call service method for adding.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirect to Vehicle metod with redirect </returns>
        [HttpPost("vehicles/add-vehicle", Name = "post-vehicle")]
        public async Task<IActionResult> AddVehicle([FromForm]VehicleMakeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (vehicleService.GetVehicleMakeByName(model.Name) == null)
                {
                    model.Id = Guid.NewGuid();
                    await vehicleService.AddVehiclesAsync(mapper.Map<IVehicleMake>(model));
                    return Redirect(Url.RouteUrl("get-vehicles"));      
                }
                else
                {
                    return Redirect(Url.RouteUrl("get-vehicles", new {message = "VehicleMake already exist in database"}));
                }
            }
            ViewBag.Message = "Add failed. Try again, and if the problem persists see your system administrator.";
            return Redirect(Url.RouteUrl("get-vehicles"));
        }

        /// <summary>
        /// HttpGet metod. Gets from urlroute id, sends to service metod id (as parameter)
        /// to get model with that id and returns it to view for editing.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ViewModel</returns>
        [HttpGet("vehicles/edit", Name = "edit-vehicle")]
        public async Task<IActionResult> EditVehicle([FromQuery(Name ="id")]Guid id, [FromQuery(Name = "message")] string message)
        {
            if (id != Guid.Empty)
            {
                try
                {
                    var vehicle = await vehicleService.GetVehicleMakeAsync(id);
                    if (vehicle != null)
                        return View(mapper.Map<VehicleMakeViewModel>(vehicle));
                }
                catch(Exception e)
                {
                    if (e.Source != null)
                        Console.WriteLine("Exception source: {0}", e.Source);
                }
            }
            return Redirect(Url.RouteUrl("get-vehicle", new { message = "Can't get model for editing. Try again, and if the problem persists see your system administrator." }));
        }

        /// <summary>
        /// HttpPost metod. Take VehicleMakeViewModel from form, and Guid id as query parameter from url route.
        /// Sends it to service to make an update of model on database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>For succes returns default Vehicle metod and for fail returns edit view</returns>
        [HttpPost("vehicles/edit", Name = "edit-post-vehicle")]
        public async Task<IActionResult> EditVehicle([FromForm]VehicleMakeViewModel model ,[FromQuery(Name="id")]Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await vehicleService.UpdateVehicleAsync(mapper.Map<IVehicleMake>(model), id);
                    if (result == 1)
                    {
                        return Redirect(Url.RouteUrl("get-vehicles"));
                    }
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                        Console.WriteLine("Exception source: {0}", e.Source);
                }
            }
            return Redirect(Url.RouteUrl("edit-vehicle", new { message = "Error saving to database. Try again, and if the problem persists see your system administrator." }));
        }

        /// <summary>
        /// HttpGet DeleteVehicle metod. Take id parameter from url route and removes model that match that model.id
        /// in database by calling service method and passing argument(id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns default vehicle view and message coresponding to result</returns>
        [HttpGet("vehicles/delete", Name = "delete-vehicle")]
        public async Task<IActionResult> DeleteVehicle([FromQuery(Name = "id")]Guid id)
        {
            if(id != Guid.Empty)
            {
                try
                {
                    var result = await vehicleService.RemoveVehicleAsync(id);
                    if (result == 1)
                    {
                    return Redirect(Url.RouteUrl("get-vehicles", new { message = "Delete success" }));
                    }
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                    Console.WriteLine("Exception source: {0}", e.Source);
                }
            }
            return Redirect(Url.RouteUrl("get-vehicles",new { message = "Delete failed. Error: Vehicle Make maybe has Vehicle Models in database. Try deleting models and then try again." }));
        }
    }
}