using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace IntergalacticRaceLeague.Controllers
{
    public class RacersController : Controller
    {
        private readonly RacerService _racerService;
        private readonly VehicleService _vehicleService;

        public RacersController(
            RacerService racerService,
            VehicleService vehicleService)
        {
            _racerService = racerService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var racers = _racerService.GetAll();
            return View(racers);
        }

        public IActionResult Details(int id)
        {
            var racer = _racerService.GetById(id);

            if (racer == null)
            {
                return NotFound();
            }

            return View(racer);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(
                _vehicleService.GetAll(),
                "Id",
                "Name");

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Racer racer)
        {
            racer.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                _racerService.Add(racer);

                return RedirectToAction("Index");
            }

            ViewBag.Vehicles = new SelectList(
                _vehicleService.GetAll(),
                "Id",
                "Name");

            return View(racer);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var racer = _racerService.GetById(id);

            if (racer == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin") &&
      racer.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            ViewBag.Vehicles = new SelectList(
                _vehicleService.GetAll(),
                "Id",
                "Name",
                racer.VehicleId);

            return View(racer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Racer racer)
        {

            var oldRacer = _racerService.GetById(racer.Id);

            if (oldRacer == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin") &&
                oldRacer.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            oldRacer.Name = racer.Name;
            oldRacer.Planet = racer.Planet;
            oldRacer.Age = racer.Age;
            oldRacer.VehicleId = racer.VehicleId;

            _racerService.Update(oldRacer);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var racer = _racerService.GetById(id);

            if (racer == null)
            {
                return NotFound();
            }

            return View(racer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var racer = _racerService.GetById(id);

            if (racer != null)
            {
                _racerService.Delete(racer);
            }

            return RedirectToAction("Index");
        }
    }
}