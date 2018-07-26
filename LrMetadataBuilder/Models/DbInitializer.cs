using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Venues.Any())
            {
                context.AddRange(
                new Venue { VenueName = "The Thunderdome",VenueAddress1 = "First Floor", VenueAddress2 = "51-53 King Street", VenueAddressTown = "Oldham", VenueAddressCounty = "Lancashire"},
                new Venue { VenueName = "University of Salford Sports Centre", VenueAddress1 = "University Road", VenueAddress2 = "", VenueAddressTown = "Salford", VenueAddressCounty = "Greater Manchester"}
                );
                context.SaveChanges();
            }

            if (!context.Events.Any())
            {
                context.AddRange(
                    new Event {  Name = "Event Name 1", EventDate = "20180714", Description = "MRDA Tier 1 North Playoffs", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 2", EventDate = "20180714", Description = "Friendly match", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 3", EventDate = "20180714", Description = "Friendly match", Cancelled = false, VenueId = 2 },
                    new Event {  Name = "Event Name 4", EventDate = "20180714", Description = "MRDA Tier 3 South Playoffs", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 5", EventDate = "20180714", Description = "MRDA Tier 2 North Playoffs", Cancelled = false, VenueId = 2 }

             );
            }
            context.SaveChanges();
        }
    }
}
