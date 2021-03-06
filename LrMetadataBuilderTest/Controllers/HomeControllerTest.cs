using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LrMetadataBuilder.Controllers;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using lrMetadataBuilderTest.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace lrMetadataBuilderTest.Controllers
{

    public class HomeControllerTest : Controller
    {
        private Mock<IEventRepository> _mockEventRepository;
        private Mock<IVenueRepository> _mockVenueRepository;
        private Mock<ITeamRepository> _mockTeamRepository;
        private Mock<IGameRepository> _mockGameRepository;
        private Mock<ILeagueRepository> _mockLeagueRepository;

        private HomeController _homeController;

        private IList<Venue> _venues;
        private IQueryable<Event> _events;
        private IQueryable<Game> _games;
        private IQueryable<Team> _teams;
        private List<League> _leagues;

        public HomeControllerTest()
        {

            //set up populated event repository
            _events = 
                new List<Event>
            {
                new Event {Id=1,Name="Event Name 1", EventDate=DateTime.Parse("2018-07-14"),Description="Event Description 1",Cancelled = false,VenueId = 1,Games = new List<Game>() }, 
                new Event {Id=2,Name="Event Name 2", EventDate=DateTime.Parse("2018-08-14"),Description="Event Description 2",Cancelled = false,VenueId = 1},
                new Event {Id=3,Name="Event Name 3", EventDate=DateTime.Parse("2018-09-14"),Description="Event Description 3",Cancelled = false,VenueId = 2},
                new Event {Id=4,Name="Event Name 4", EventDate=DateTime.Parse("2018-10-14"),Description="Event Description 4",Cancelled = false,VenueId = 1},
                new Event {Id=5,Name="Event Name 5", EventDate=DateTime.Parse("2018-11-14"),Description="Event Description 5",Cancelled = false,VenueId = 2}
            }.AsQueryable();

            _mockEventRepository = DataHelper.GetTestEventRepository();
            _mockVenueRepository = DataHelper.GetTestVenueRepository();
            _mockLeagueRepository = DataHelper.GetTestLeagueRepository();

            _teams = new List<Team>
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

            _games = new List<Game>
            {
                new Game
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    WhistleTime = DateTime.Parse("11:00")
                },
                new Game
                {
                    Id = 2,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    WhistleTime = DateTime.Parse("14:00")
                }
            }.AsQueryable();

            _homeController = new HomeController(_mockEventRepository.Object, _mockVenueRepository.Object);

        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            //Arrange

            //Act
            var result = _homeController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.IsAssignableFrom<IList<Event>>(model.Events);
            Assert.Equal(5, model.Events.Count());

        }

        [Fact]
        public void Details_ReturnsNotFound_WhenNoIdProvided()
        {
            //Arrange
            // done in constructor

            //Act
            var result = _homeController.Details(null);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenEventDoesNotExist()
        {
            //passing an id to Details with no corresponding event 
            // should return not found

            // pass in an int for an event that doesn't exist
            var result = _homeController.Details(6);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsDetailsView_WhenEventExists()
        {
            //Arrange 
            var mockId = 1;
            var mockVenue = new Venue()
            {
                Id = 1,
                VenueName = "VenueName 1",
                VenueAddress1 = "VenueAddress1 1",
                VenueAddress2 = "VenueAddress2 1",
                VenueAddressTown = "VenueAddressTown 1",
                VenueAddressCounty = "VenueAddressCounty 1"
            };
            var mockEvent = new EventViewModel()
            {
                Id = 1,
                Name = "Event Name 1",
                EventDate = DateTime.Parse("2018-07-14"),
                Description = "Event Description 1",
                Venue = mockVenue,
                Games = new List<Game>()
            };

            //Act - now try one that should be there
            var result = _homeController.Details(mockId);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<EventViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_ReturnsEditEventViewModel()
        {
            //Arrange
            //done in constructor

            //Act
            var result = _homeController.Create();

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<EventEditViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_ReturnsEventEditViewModel_WhenModelIsInvalid()
        {
            //Arrange
            var mockEventEditViewModel = new EventEditViewModel { Id = 20, EventName = "Test Event"};
            _homeController.ModelState.AddModelError("EventDate","Required");
            var mockEvent = Mock.Of<Event>();
            //Act
            var result = _homeController.Create(mockEventEditViewModel);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(mockEventEditViewModel, viewResult.ViewData.Model);
            _mockEventRepository.Verify( evnt => evnt.Add(mockEvent), Times.Never);

        }

        [Fact]
        public void Create_RedirectsToActionIndex_WhenModelIsValid()
        {
            //Arrange
            var mockEventEditViewModel = new EventEditViewModel()
            {
                Id = 20,
                EventName = "Test Event Name",
                EventDate = DateTime.Parse("2018-08-14"),
                SelectedVenue = 1
            };

            //Act
            var result = _homeController.Create(mockEventEditViewModel);

            //Assert
            Assert.NotNull(result);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);

        }


        [Fact]
        public void Delete_ReturnsNotFoundWhenEventDoesNotExist()
        {
            //Arrange
            //done in controller

            //Act
            var result = _homeController.Delete(20);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsEventViewWhenEventExists()
        {
            //Arrange
            // done in constructor

            //Act
            var result = _homeController.Delete(1);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Event>(viewResult.ViewData.Model);
        }

        [Fact]
        public void DeleteConfirmed_ReturnsRedirectToIndex()
        {
            //Arrange
            //  done in constructor
            //Act
            var result = _homeController.DeleteConfirmed(1);

            //Assert
            Assert.NotNull(result);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);

        }

        [Fact]
        public void Edit_ReturnsBadRequestWhenNoEventIdPassed()
        {
            //Arrange
            // done in constructor

            //Act
            var result = _homeController.Edit(null);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestResult>(result);
        }

        [Fact]
        public void Edit_ReturnsNotFoundWhenEventDoesNotExist()
        {
            //Arrange
            // done in constructor

            //Act
            var result = _homeController.Edit(20);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_ReturnsEditEventViewModelWhenEventExists()
        {
            //Arrange
            // done in constructor

            //Act
            var result = _homeController.Edit(1);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<EventEditViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void EditConfirmed_ReturnsNotFound_WhenEventDoesNotExist()
        {
            //Arrange
            var eventViewModelMock = Mock.Of<EventEditViewModel>();
            eventViewModelMock.Id = 20;

            //Act
            var result = _homeController.EditConfirmed(eventViewModelMock);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void EditConfirmed_ReturnsRedirectToIndex_WhenEventExists()
        {
            //Arrange
            var eventViewModelMock = Mock.Of<EventEditViewModel>();
            eventViewModelMock.Id = 1;

            //Act
            var result = _homeController.EditConfirmed(eventViewModelMock);

            //Assert
            Assert.NotNull(result);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
        }
    }
}
