﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Models;

namespace LrMetadataBuilder.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Event> Events;
        public Event Event;
        public IEnumerable<Venue> Venues;
    }
}
