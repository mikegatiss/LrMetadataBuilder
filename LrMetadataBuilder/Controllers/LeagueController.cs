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
            ViewBag.Title = "Manage Leagues";

            var leagueViewModel = new LeagueViewModel();
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: League/Edit/5
        public IActionResult Edit(int id)
        {
            var league = _leagueRepository.GetLeagueById(id);
            if (league == null)
            {
                return NotFound();
            }
            return View(league);
        }

        // POST: League/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] League league)
        {
            if (id != league.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _leagueRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.Id))
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
            return View(league);
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
            return RedirectToAction(nameof(Index));
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
