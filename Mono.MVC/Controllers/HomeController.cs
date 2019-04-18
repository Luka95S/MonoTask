using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono.Models;
using Mono.Models.Common;
using Mono.MVC.Models;
using Mono.Services.Common;
using Mono.Common;

namespace Mono.MVC.Controllers
{
    /// <summary>
    /// HomeController class that inherits AspNetCore.MVC.Controller class with view support
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="vehicleService"></param>
        /// <param name="mapper"></param>
        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Index metod. Gets parameters from query, sets them to filter model and sends filter to service.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="page"></param>
        /// <param name="sortOrder"></param>
        /// <param name="sortBy"></param>
        /// <param name="searchBy"></param>
        /// <returns>viewModel as parameter in View() and message if there is no models with search argument in database</returns>
        [HttpGet("", Name = "index")]
        public IActionResult Index([FromQuery(Name = "message")] string message, [FromQuery(Name = "page")]int page = 1, [FromQuery(Name = "sortOrder")] string sortOrder = "asc", [FromQuery(Name = "sortBy")] string sortBy = "name", [FromQuery(Name="searchby")] string searchBy ="")
        {
            var filter = new Filter();
            var sort = new Sorting();
            var paging = new Paging();
            var embed = new EmbedCollection("VehicleModels");
            paging.Page = page;
            sort.SortOrder = sortOrder;
            sort.SortBy = sortBy;
            searchBy = searchBy == null ? "" : searchBy;
            filter.SearchBy = searchBy;
            IVehicleMake vehicles = mapper.Map<VehicleMake>(vehicleService.GetAllVehicles(filter, paging, sort, embed).Result);
            ViewBag.Previous = paging.Skip == 0 ? false : true;
            ViewBag.Next = vehicles.TotalItemsCount - paging.Skip - paging.NumberOfItems <= 0 ? false : true;

            if (vehicles.VehicleMakes != null)
            {
                ViewBag.Message = vehicles.TotalItemsCount == 0 ? "No search items found! Try again" : message;
                return View(mapper.Map<VehicleMakeViewModel>(vehicles));
            }
            ViewBag.Message = "There are no Vehicles in database. Add them!";
            return View(mapper.Map<VehicleMakeViewModel>(vehicles));
        }
    }
}

