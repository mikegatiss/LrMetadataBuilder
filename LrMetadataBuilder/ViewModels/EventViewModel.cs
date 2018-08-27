using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Models;

namespace LrMetadataBuilder.ViewModels
{
    public class EventViewModel
    {
        public int Id;
        public string Name;
        public string Description;
        public DateTime EventDate;

        public Venue Venue;
        public IEnumerable<Game> Games;

    }
}
