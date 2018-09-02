using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LrMetadataBuilder.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IEventRepository _eventRepository;

        public GameController(IGameRepository gameRepository, ITeamRepository teamRepository,
            IEventRepository eventRepository)
        {
            _gameRepository = gameRepository;
            _teamRepository = teamRepository;
            _eventRepository = eventRepository;
        }

        // GET: Games
        public IActionResult Index(int? eventId)
        {
            if (eventId != null)
            {
                var viewModel = _gameRepository.GetGamesByEventId((int) eventId);
                if (viewModel != null)
                {
                    return View(viewModel);
                }

                return NotFound();
            }

            return BadRequest();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventGameListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Games != null)
                {
                    _gameRepository.Save(viewModel.Games);
                }

                return View(viewModel);
            }

            return BadRequest();
        }

    }
}
