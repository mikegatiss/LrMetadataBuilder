using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LrMetadataBuilder.Models
{
    public class Event
    {

        public Event()
        {
            Games = new HashSet<Game>();
        }
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = @"{ 0:dd MMMM yyyy }")]
        public DateTime EventDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public bool Cancelled { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
