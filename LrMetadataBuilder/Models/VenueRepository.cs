using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class VenueRepository : IVenueRepository
    {
        private readonly AppDbContext _appDbContext;

        public VenueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Venue> GetAllVenues()
        {
            return _appDbContext.Venues;
        }

        public Venue GetVenueById(int id)
        {
            return _appDbContext.Venues.FirstOrDefault(v => v.Id == id);
        }
    }
}
