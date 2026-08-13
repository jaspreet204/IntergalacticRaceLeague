using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IntergalacticRaceLeague.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetAll();
            return View(vehicles);
        }

        public IActionResult Details(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {

                vehicle.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _vehicleService.Add(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }


            if (!User.IsInRole("Admin") &&
                vehicle.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            return View(vehicle);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
          
                var oldVehicle = _vehicleService.GetById(vehicle.Id);

                if (oldVehicle == null)
                {
                    return NotFound();
                }

                if (!User.IsInRole("Admin") &&
                    oldVehicle.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Forbid();
                }

                vehicle.UserId = oldVehicle.UserId;
                if (ModelState.IsValid)
            {
                _vehicleService.Update(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                _vehicleService.Delete(vehicle);
            }

            return RedirectToAction("Index");
        }
    }
}