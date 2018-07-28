using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> GetAllVenues();
        Venue GetVenueById(int venueId);
        void Add(Venue venue);
        void Delete(Venue venue);
        void Edit(Venue venue);
        void Save();

    }
}
