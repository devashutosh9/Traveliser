using Microsoft.AspNetCore.Mvc;
using Traveliser.Models;

namespace Traveliser.Controllers
{
    public class FlightSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            TraveliserService traveliserService = new TraveliserService();
            var airports = await traveliserService.GetAirportData();

            TempData["airports"] = airports;

            return View();
        }
    }
}
