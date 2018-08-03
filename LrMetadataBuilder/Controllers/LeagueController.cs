using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;

namespace LrMetadataBuilder.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        // GET: League
        public IActionResult Index()
        {
            var leagues = _leagueRepository.GetAllLeagues().OrderBy(l => l.Name);

            var leagueViewModel = new LeagueViewModel()
            {
                Title = "Manage Leagues",
                Leagues = leagues.ToList()
            };
            return View(leagueViewModel);
        }

        // GET: League/Details/5
        public IActionResult Details(int id)
        {

            var league = _leagueRepository.GetLeagueById(id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
 
        }

        // GET: League/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: League/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] League league)
        {
            if (ModelState.IsValid)
            {
                _leagueRepository.Add(league);
                _leagueRepository.Save();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        // GET: League/Edit/id
        public IActionResult Edit(int id)
        {
            var league = _leagueRepository.GetLeagueById(id);
            if (league == null)
            {
                return NotFound();
            }
           
            var viewModel = new LeagueViewModel()
            {
                Name = league.Name,
                Id = league.Id
            };
            return View(viewModel);
        }

        // POST: League/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] LeagueViewModel viewModel)
        {
            if (id != viewModel.League.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var league = _leagueRepository.GetLeagueById(id);
                    if (league == null)
                    {
                        return NotFound();
                    }

                    league.Name = viewModel.Name;

                    _leagueRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        // GET: League/Delete/5
        public IActionResult Delete(int id)
        {

            var league = _leagueRepository.GetLeagueById(id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // POST: League/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var league = _leagueRepository.GetLeagueById(id);
            _leagueRepository.Delete(league);
            _leagueRepository.Save();
            return RedirectToAction("Index");
        }

        private bool LeagueExists(int id)
        {
            var league = _leagueRepository.GetLeagueById(id);
            if (league == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
