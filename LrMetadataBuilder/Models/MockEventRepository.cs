using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class MockEventRepository : IEventRepository
    {
        private List<Event> _events;

        public MockEventRepository()
        {
            if (_events == null)
            {
                InitializeEvents();
            }
        }

        private void InitializeEvents()
        {
            _events = new List<Event>
            {
                new Event {Id=1,Name="Event Name 1", EventDate = DateTime.Parse("20180714"),Description="MRDA Tier 1 North Playoffs",Cancelled = false,VenueId = 1},
                new Event {Id=2,Name="Event Name 2", EventDate = DateTime.Parse("20180814"),Description="Friendly match",Cancelled = false,VenueId = 1},
                new Event {Id=3,Name="Event Name 3", EventDate = DateTime.Parse("20180914"),Description="Friendly match",Cancelled = false,VenueId = 2},
                new Event {Id=4,Name="Event Name 4", EventDate = DateTime.Parse("20181014"),Description="MRDA Tier 3 South Playoffs",Cancelled = false,VenueId = 1},
                new Event {Id=5,Name="Event Name 5", EventDate = DateTime.Parse("20181114"),Description="MRDA Tier 2 North Playoffs",Cancelled = false,VenueId = 2}

            };
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }

        public Event GetEventById(int eventId)
        {
            return _events.FirstOrDefault(e => e.Id == eventId);
        }

        public void Add(Event evnt)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event evnt)
        {
            throw new NotImplementedException();
        }

        public void Edit(Event evnt)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
