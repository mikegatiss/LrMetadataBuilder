using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LrMetadataBuilder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LrMetadataBuilder.ViewModels
{
    public class EventGameListViewModel
    {
        [Display(Name="Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Event")]
        public string EventName { get; set; }

        [Display(Name="Event Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{ 0:dd MMMM yyyy }")]
        public DateTime EventDate { get; set; }

        [Display(Name="Venue")]
        public Venue Venue { get; set; }

        public List<GameListViewModel> Games { get; set; }
    }
}
