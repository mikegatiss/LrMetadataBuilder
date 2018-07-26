using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LrMetadataBuilder.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public bool Cancelled { get; set; }

        public virtual Venue Venue { get; set; }
    }
}
