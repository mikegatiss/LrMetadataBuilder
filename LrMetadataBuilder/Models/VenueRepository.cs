using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return from v in _appDbContext.Venues
                orderby v.VenueName
                select new SelectListItem
                {
                    Text = v.VenueName,
                    Value = v.Id.ToString()
                };
        }
        public void Add(Venue venue)
        {
            throw new NotImplementedException();
        }

        public void Delete(Venue venue)
        {
            throw new NotImplementedException();
        }

        public void Edit(Venue venue)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
