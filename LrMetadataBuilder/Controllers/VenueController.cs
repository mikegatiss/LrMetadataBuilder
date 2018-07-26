using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Data;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LrMetadataBuilder.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Venues List";
            var venues = _venueRepository.GetAllVenues().OrderBy(v => v.VenueName);
            var venueViewModel = new VenueViewModel()
            {
                Title = "Welcome to the Metadata Builder",
                Venues = venues.ToList()
            };
            return View(venueViewModel);
        }

        public IActionResult Details(int id)
        {
            var venue = _venueRepository.GetVenueById(id);
            if (venue == null)
                return NotFound();
            return View(venue);
        }
    }
}