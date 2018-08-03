using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LrMetadataBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IVenueRepository _venueRepository;

        public HomeController(IEventRepository eventRepository, IVenueRepository venueRepository)
        {
            _eventRepository = eventRepository;
            _venueRepository = venueRepository;
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

        public IActionResult Create()
        {
            var viewModel = new EventEditViewModel()
            {
                Title = "Add New Event",
                SelectVenues = _venueRepository.GetSelectListItems(),
                SelectedVenue = 1
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectVenues = _venueRepository.GetSelectListItems();
                viewModel.SelectedVenue = 1;

                return View(viewModel);
            }

            var evnt = new Event()
            {
                Name = viewModel.EventName,
                EventDate = viewModel.EventDate,
                Description = viewModel.Description,
                VenueId = viewModel.SelectedVenue,
                Cancelled = false
            };

            _eventRepository.Add(evnt);
            _eventRepository.Save();

            return RedirectToAction("Index");
        }

        //public IActionResult Delete(Event evnt)
        //{
        //    _eventRepository.Delete(evnt);
        //    _eventRepository.Save();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Delete(int id)
        {
            var evnt = _eventRepository.GetEventById(id);
            if (evnt == null)
            {
                return NotFound();
            }

            return View(evnt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var evnt = _eventRepository.GetEventById(id);
            _eventRepository.Delete(evnt);
            _eventRepository.Save();
            return RedirectToAction("Index");
        }

        //GET: /League/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event evnt = _eventRepository.GetEventById((int)id); // if id is null we won't reach this point
            if (evnt == null)
            {
                return NotFound();
            }

            var viewModel = new EventEditViewModel()
            {
                Title = "Edit Event",
                Id = evnt.Id,
                EventName = evnt.Name,
                EventDate = evnt.EventDate,
                Description = evnt.Description,
                SelectVenues = _venueRepository.GetSelectListItems(),
                SelectedVenue = evnt.VenueId,
                Cancelled = evnt.Cancelled
            };

            return View(viewModel);
        }

        //POST: /League/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,EventName,EventDate,Description,SelectedVenue,SelectVenues,Cancelled")]
            EventEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var evnt = _eventRepository.GetEventById(viewModel.Id);
                if (evnt == null)
                {
                    return NotFound();
                }

                evnt.Name = viewModel.EventName;
                evnt.Description = viewModel.Description;
                evnt.EventDate = viewModel.EventDate;
                evnt.VenueId = viewModel.SelectedVenue;
                evnt.Cancelled = viewModel.Cancelled;

                _eventRepository.Edit(evnt);
                _eventRepository.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
