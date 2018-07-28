using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LrMetadataBuilder.Models
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public virtual IEnumerable<Event> GetAllEvents()
        {
            return _appDbContext.Events.Include(e=>e.Venue);
        }

        public Event GetEventById(int eventId)
        {
            var query = _appDbContext.Events.Include(e => e.Venue);
            return query.FirstOrDefault(e => e.Id == eventId);
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
