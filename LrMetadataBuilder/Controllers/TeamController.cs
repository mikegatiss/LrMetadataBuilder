using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;

namespace LrMetadataBuilder.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILeagueRepository _leagueRepository;

        public TeamController(ITeamRepository teamRepository, ILeagueRepository leagueRepository)
        {
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
        }

        // GET: Team
        public  IActionResult Index()
        {
            ViewBag.Title = "Available Teams";

            var teams = _teamRepository.GetAllTeams().OrderBy(t => t.League.Name).ThenBy(t => t.Name);
            var teamViewModel = new TeamViewModel()
            {
                Teams = teams.ToList()
            };

            return View(teamViewModel);

        }

        // GET: Team/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teamRepository.GetTeamById((int) id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            var viewModel = new TeamViewModel()
            {
                Title = "Add New Team",
                SelectLeagues = _leagueRepository.GetSelectListItems(),
                SelectedLeague = 1
            };

            return View(viewModel);
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,LeagueId,SelectedLeague,SelectLeagues")] TeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectLeagues = _leagueRepository.GetSelectListItems();
                viewModel.SelectedLeague = 1;

                return View(viewModel);
            }

            var team = new Team()
            {
                Name = viewModel.Name,
                LeagueId = viewModel.SelectedLeague
            };

            _teamRepository.Add(team);
            _teamRepository.Save();

            return RedirectToAction("Index");
        }

        // GET: Team/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = _teamRepository.GetTeamById((int) id);
            if (team == null)
            {
                return NotFound();
            }

            var viewModel = new TeamViewModel()
            {
                Title = "Edit Team",
                Id = team.Id,
                Name = team.Name,
                SelectLeagues = _teamRepository.GetSelectListItems(),
                SelectedLeague = team.LeagueId
            };

            return View(viewModel);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,LeagueId,SelectedLeague,SelectLeagues")] TeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var team = _teamRepository.GetTeamById(viewModel.Id);
                if (team == null)
                {
                    return NotFound();
                }

                team.Name = viewModel.Name;
                team.LeagueId = viewModel.SelectedLeague;

                _teamRepository.Edit(team);
                _teamRepository.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Team/Delete/5
        public IActionResult Delete(int id)
        {
            var team = _teamRepository.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var team = _teamRepository.GetTeamById(id);
            _teamRepository.Delete(team);
            _teamRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
