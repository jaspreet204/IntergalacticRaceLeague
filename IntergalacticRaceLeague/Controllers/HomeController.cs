using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntergalacticRaceLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly RacerService _racerService;
        private readonly VehicleService _vehicleService;
        private readonly TournamentService _tournamentService;

        public HomeController(
            RacerService racerService,
            VehicleService vehicleService,
            TournamentService tournamentService)
        {
            _racerService = racerService;
            _vehicleService = vehicleService;
            _tournamentService = tournamentService;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            model.TotalRacers = _racerService.GetAll().Count;
            model.TotalVehicles = _vehicleService.GetAll().Count;
            model.TotalTournaments = _tournamentService.GetAll().Count;

            return View(model);
        }
    }
}