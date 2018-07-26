using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class MockVenueRepository : IVenueRepository
    {
        private List<Venue> _venues;

        public MockVenueRepository()
        {
            if (_venues == null)
            {
                InitializeVenues();
            }
        }

        private void InitializeVenues()
        {
            _venues = new List<Venue>
            {
                new Venue
                {
                    Id = 1,
                    VenueName = "The Thunderdome",
                    VenueAddress1 = "First Floor",
                    VenueAddress2 = "51-53 King Street",
                    VenueAddressTown = "Oldham",
                    VenueAddressCounty = "Lancashire"
                },
                new Venue
                {
                    Id = 2,
                    VenueName = "University of Salford Sports Centre",
                    VenueAddress1 = "University Road",
                    VenueAddress2 = "",
                    VenueAddressTown = "Salford",
                    VenueAddressCounty = "Greater Manchester"
                }
            };
        }

        public IEnumerable<Venue> GetAllVenues()
        {
            return _venues;
        }

        public Venue GetVenueById(int venueId)
        {
            return _venues.FirstOrDefault(v => v.Id == venueId);
        }

        public void AddVenue(Venue venue)
        {
            _venues.Add(venue);
        }
    }
}
