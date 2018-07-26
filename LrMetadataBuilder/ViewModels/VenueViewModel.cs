using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Models;

namespace LrMetadataBuilder.ViewModels
{
    public class VenueViewModel
    {
        public string Title { get; set; }
        public List<Venue> Venues { get; set; }
    }
}
