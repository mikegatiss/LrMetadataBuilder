using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress1 { get; set; }
        public string VenueAddress2 { get; set; }
        public string VenueAddressTown { get; set; }
        public string VenueAddressCounty { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
