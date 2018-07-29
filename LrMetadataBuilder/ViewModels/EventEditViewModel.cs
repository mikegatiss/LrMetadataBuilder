using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LrMetadataBuilder.ViewModels
{
    public class EventEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Please provide an Event Name")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please select a date for the event")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select the venue")]
        public int SelectedVenue { get; set; }
        public IEnumerable<SelectListItem> SelectVenues { get; set; }

        public bool Cancelled { get; set; }

    }
}
