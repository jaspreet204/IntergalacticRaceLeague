using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntergalacticRaceLeague.Controllers
{
    public class RacerTournamentsController : Controller
    {
        private readonly RacerTournamentService _racerTournamentService;
        private readonly RacerService _racerService;
        private readonly TournamentService _tournamentService;

        public RacerTournamentsController(
            RacerTournamentService racerTournamentService,
            RacerService racerService,
            TournamentService tournamentService)
        {
            _racerTournamentService = racerTournamentService;
            _racerService = racerService;
            _tournamentService = tournamentService;
        }

        public IActionResult Create()
        {
            ViewBag.Racers = new SelectList(
                _racerService.GetAll(),
                "Id",
                "Name");

            ViewBag.Tournaments = new SelectList(
                _tournamentService.GetAll(),
                "Id",
                "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(RacerTournament racerTournament)
        {
            if (ModelState.IsValid)
            {
                _racerTournamentService.Add(racerTournament);
                return RedirectToAction("Index", "Tournaments");
            }

            ViewBag.Racers = new SelectList(
                _racerService.GetAll(),
                "Id",
                "Name");

            ViewBag.Tournaments = new SelectList(
                _tournamentService.GetAll(),
                "Id",
                "Name");

            return View(racerTournament);
        }
    }
}