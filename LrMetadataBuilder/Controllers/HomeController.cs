using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;

namespace LrMetadataBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IVenueRepository _venueRepository;

        public HomeController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Available Events";
            var events = _eventRepository.GetAllEvents().OrderBy(e => e.EventDate);
            
            var homeViewModel = new HomeViewModel()
            {
                Title = "Metadata Builder",
                Events = events.ToList()
            };
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var evt = _eventRepository.GetEventById(id);
            if (evt == null)
            {
                return NotFound();
            }

            return View(evt);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
