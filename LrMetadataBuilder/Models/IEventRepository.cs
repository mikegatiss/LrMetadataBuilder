using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int evntId);
        void Add(Event evnt);
        void Delete(Event evnt);
        void Edit(Event evnt);
        void Save();
    }
}
