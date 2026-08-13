using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntergalacticRaceLeague.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly TournamentService _tournamentService;

        public TournamentsController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // Anyone can view tournaments
        public IActionResult Index()
        {
            var tournaments = _tournamentService.GetAll();
            return View(tournaments);
        }

        // Anyone can view tournament details
        public IActionResult Details(int id)
        {
            var tournament = _tournamentService.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.Add(tournament);
                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var tournament = _tournamentService.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.Update(tournament);
                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var tournament = _tournamentService.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var tournament = _tournamentService.GetById(id);

            if (tournament != null)
            {
                _tournamentService.Delete(tournament);
            }

            return RedirectToAction("Index");
        }
    }
}