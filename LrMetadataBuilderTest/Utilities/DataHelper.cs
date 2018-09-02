using System;
using System.Collections.Generic;
using System.Linq;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;

namespace lrMetadataBuilderTest.Utilities
{
    internal class DataHelper
    {



        internal static Mock<IEventRepository> GetTestEventRepository()
        {
            var events =
                new List<Event>
                {
                    new Event {Id=1,Name="Event Name 1", EventDate=DateTime.Parse("2018-07-14"),Description="Event Description 1",Cancelled = false,VenueId = 1,Games = new List<Game>() },
                    new Event {Id=2,Name="Event Name 2", EventDate=DateTime.Parse("2018-08-14"),Description="Event Description 2",Cancelled = false,VenueId = 1},
                    new Event {Id=3,Name="Event Name 3", EventDate=DateTime.Parse("2018-09-14"),Description="Event Description 3",Cancelled = false,VenueId = 2},
                    new Event {Id=4,Name="Event Name 4", EventDate=DateTime.Parse("2018-10-14"),Description="Event Description 4",Cancelled = false,VenueId = 1},
                    new Event {Id=5,Name="Event Name 5", EventDate=DateTime.Parse("2018-11-14"),Description="Event Description 5",Cancelled = false,VenueId = 2}
                }.AsQueryable();

            var mockEventRepository = new Mock<IEventRepository>();
            mockEventRepository.Setup(mer => mer.GetAllEvents()).Returns(events);
            mockEventRepository.Setup(mer => mer.GetEventById(
                    It.IsAny<int>()))
                .Returns((int i) => events.SingleOrDefault(x => x.Id == i));
            mockEventRepository.Setup(mer => mer.Add(It.IsAny<Event>()))
                .Verifiable();

            return mockEventRepository;
        }

        internal static Mock<IGameRepository> GetTestGameRepository()
        {
            var games = new List<Game>
            {
                new Game {Id = 1,HomeTeamId = 1,AwayTeamId = 2,WhistleTime = DateTime.Parse("11:00")},
                new Game {Id = 2,HomeTeamId = 1,AwayTeamId = 2,WhistleTime = DateTime.Parse("14:00")}
            }.AsQueryable();

            var eventGameListViewModel = new EventGameListViewModel()
            {
                EventName = "Event Name",
                EventDate = DateTime.Parse("2018-08-14"),
                EventId = 1
            };

            var mockGameRepository = new Mock<IGameRepository>();
            mockGameRepository.Setup(mgr => mgr.GetAllGames()).Returns(games);
            mockGameRepository.Setup(mgr => mgr.GetGamesByEventId(1))
                .Returns(eventGameListViewModel);

            return mockGameRepository;
        }

        internal static Mock<IVenueRepository> GetTestVenueRepository()
        {
            var venues = new List<Venue>
            {
                new Venue
                {
                    Id = 1,
                    VenueName = "VenueName 1",
                    VenueAddress1 = "VenueAddress1 1",
                    VenueAddress2 = "VenueAddress2 1",
                    VenueAddressTown = "VenueAddressTown 1",
                    VenueAddressCounty = "VenueAddressCounty 1"
                },
                new Venue
                {
                    Id = 2,
                    VenueName = "VenueName 2",
                    VenueAddress1 = "VenueAddress1 2",
                    VenueAddress2 = "VenueAddress2 2",
                    VenueAddressTown = "VenueAddressTown 2",
                    VenueAddressCounty = "VenueAddressCounty 2"
                }

            };
            var mockVenueRepository = new Mock<IVenueRepository>();
            mockVenueRepository.Setup(mvr => mvr.GetAllVenues()).Returns(venues);
            mockVenueRepository.Setup(mvr => mvr.GetVenueById(
                    It.IsAny<int>()))
                .Returns((int i) => venues.SingleOrDefault(x => x.Id == i));
            mockVenueRepository.Setup(mvr => mvr.GetSelectListItems())
                .Returns(
                    new List<SelectListItem>
                    {
                        new SelectListItem() {Value = "1", Text = "Venue 1"},
                        new SelectListItem() {Value = "2", Text = "Venue 2"}
                    }
                );
            return mockVenueRepository;

        }

        internal static Mock<ILeagueRepository> GetTestLeagueRepository()
        {
            var leagues = new List<League>
            {
                new League {Id = 1, Name = "League 1"},
                new League {Id = 2, Name = "League 2"}
            };

            var mockLeagueRepository = new Mock<ILeagueRepository>();
            mockLeagueRepository.Setup(mlr => mlr.GetAllLeagues()).Returns(leagues);
            mockLeagueRepository.Setup(mlr => mlr.GetLeagueById(
                    It.IsAny<int>()))
                .Returns((int i) => leagues.SingleOrDefault(x => x.Id == i));
            mockLeagueRepository.Setup(mlr => mlr.GetSelectListItems())
                .Returns(
                    new List<SelectListItem>
                    {
                        new SelectListItem() {Value = "1", Text = "League 1"},
                        new SelectListItem() {Value = "2", Text = "League 2"}
                    }
                );

            return mockLeagueRepository;
        }

        internal static Mock<ITeamRepository> GetTestTeamRepository()
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "Team1",
                    LeagueId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "Team2",
                    LeagueId = 2
                }
            }.AsQueryable();
            var mockTeamRepository = new Mock<ITeamRepository>();
            mockTeamRepository.Setup(mtr => mtr.GetAllTeams()).Returns(teams);

            return mockTeamRepository;
        }
    }
}
