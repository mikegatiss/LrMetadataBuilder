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

        public EventRepository()
        {
        }

        public virtual IEnumerable<Event> GetAllEvents()
        {
            return _appDbContext.Events.Include(e=>e.Venue);
        }

        public Event GetEventById(int? eventId)
        {
            var query = _appDbContext.Events.Include(e => e.Venue);
            return query.SingleOrDefault(e => e.Id == (int) eventId);
        }

        public void Add(Event evnt)
        {
            _appDbContext.Events.Add(evnt);
        }

        public void Delete(Event evnt)
        {
            _appDbContext.Events.Remove(evnt);
        }

        public void Edit(Event evnt)
        {
            _appDbContext.Entry(evnt).State = EntityState.Modified;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
