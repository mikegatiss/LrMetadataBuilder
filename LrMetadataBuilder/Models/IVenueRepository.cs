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
        
    }
}
