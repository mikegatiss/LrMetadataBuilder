using System;
using System.Linq;
using Microsoft.WindowsAzure.Storage;

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
                    new Event {  Name = "Event Name 1", EventDate = DateTime.Parse("20180714"), Description = "MRDA Tier 1 North Playoffs", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 2", EventDate = DateTime.Parse("20180814"), Description = "Friendly match", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 3", EventDate = DateTime.Parse("20180914"), Description = "Friendly match", Cancelled = false, VenueId = 2 },
                    new Event {  Name = "Event Name 4", EventDate = DateTime.Parse("20181014"), Description = "MRDA Tier 3 South Playoffs", Cancelled = false, VenueId = 1 },
                    new Event {  Name = "Event Name 5", EventDate = DateTime.Parse("20181114"), Description = "MRDA Tier 2 North Playoffs", Cancelled = false, VenueId = 2 }
                );
            }

            if (!context.Leagues.Any())
            {
                context.AddRange(
                    new League {Name = "Manchester Roller Derby"},
                    new League {Name = "Rainy City Roller Derby"},
                    new League {Name = "Auld Reekie Roller Girls"},
                    new League {Name = "Barrow Infernos"},
                    new League {Name = "Basingstoke Bullets Roller Derby"},
                    new League {Name = "Bath Roller Derby Girls"},
                    new League {Name = "Belfast Roller Derby"},
                    new League {Name = "Big Bucks High Rollers"},
                    new League {Name = "Birmingham Blitz Dames"},
                    new League {Name = "Borderland Brawlers Roller Derby"},
                    new League {Name = "Bridgend Roller Derby"},
                    new League {Name = "Brighton Rockers Roller Derby"},
                    new League {Name = "Bristol Roller Derby"},
                    new League {Name = "Cambridge Rollerbillies"},
                    new League {Name = "Central City Roller Derby"},
                    new League {Name = "Cambridge Rollerbillies"},
                    new League {Name = "Central City Roller Derby"},
                    new League {Name = "Birmingham, UK"},
                    new League {Name = "Cornwall Roller Derby"},
                    new League {Name = "Crash Test Brummies"},
                    new League {Name = "Croydon Roller Derby"},
                    new League {Name = "Dare Valley Vixens"},
                    new League {Name = "Dolly Rockit Rollers"},
                    new League {Name = "Dundee Roller Derby"},
                    new League {Name = "Durham Roller Derby"},
                    new League {Name = "Fierce Valley Roller Girls"},
                    new League {Name = "Glasgow Roller Derby"},
                    new League {Name = "Granite City Roller Derby"},
                    new League {Name = "Halifax Bruising Banditas"},
                    new League {Name = "Hereford Roller Girls"},
                    new League {Name = "Hertfordshire Roller Derby"},
                    new League {Name = "Hot Wheels Roller Derby"},
                    new League {Name = "Hulls Angels Roller Dames"},
                    new League {Name = "Kent Roller Derby"},
                    new League {Name = "Killa Hurtz Roller Derby"},
                    new League {Name = "Leeds Roller Derby"},
                    new League {Name = "Lincolnshire Bombers"},
                    new League {Name = "Liverpool Roller Birds"},
                    new League {Name = "London Rockin' Rollers"},
                    new League {Name = "London Rollergirls"},
                    new League {Name = "Mansfield Roller Derby"},
                    new League {Name = "Middlesbrough Roller Derby"},
                    new League {Name = "Milton Keynes Roller Derby"},
                    new League {Name = "Neath Port Talbot Roller Derby"},
                    new League {Name = "New Town Roller Girls"},
                    new League {Name = "Newcastle Roller Girls"},
                    new League {Name = "Norfolk Roller Derby"},
                    new League {Name = "North Cheshire Victory Rollers"},
                    new League {Name = "North Devon Roller Derby"},
                    new League {Name = "North Wales Roller Derby"},
                    new League {Name = "Nottingham Roller Derby"},
                    new League {Name = "Oxford Roller Derby"},
                    new League {Name = "Plymouth City Roller Derby"},
                    new League {Name = "Ponty Pirate Derby Dames"},
                    new League {Name = "Portsmouth Roller Wenches"},
                    new League {Name = "Preston Roller Girls"},
                    new League {Name = "Reaper Roller Derby"},
                    new League {Name = "Rebellion Roller Derby"},
                    new League {Name = "Roller Derby Leicester"},
                    new League {Name = "Royal Windsor Roller Girls"},
                    new League {Name = "Severn Roller Torrent"},
                    new League {Name = "Sheffield Steel Rollergirls"},
                    new League {Name = "Southern Discomfort Roller Derby"},
                    new League {Name = "Spa Town Roller Derby"},
                    new League {Name = "Swansea City Roller Derby"},
                    new League {Name = "SWAT Roller Derby"},
                    new League {Name = "Teesside Skate Invaders"},
                    new League {Name = "The Inhuman League"},
                    new League {Name = "Tiger Bay Brawlers"},
                    new League {Name = "Wakey Wheeled Cats"},
                    new League {Name = "Wiltshire Roller Derby"},
                    new League {Name = "Wirral Roller Derby"},
                    new League {Name = "Wolverhampton Honour Rollers"},
                    new League {Name = "York Minxters Roller Derby"}
                );
            }

            context.SaveChanges();
        }
    }
}
