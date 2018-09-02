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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using lrMetadataBuilderTest.Utilities;
using Microsoft.EntityFrameworkCore.Query.ResultOperators;

namespace lrMetadataBuilderTest.Controllers
{

    public class GameControllerTest : Controller
    {
        private Mock<IEventRepository> _mockEventRepository;
        private Mock<IVenueRepository> _mockVenueRepository;
        private Mock<ITeamRepository> _mockTeamRepository;
        private Mock<IGameRepository> _mockGameRepository;
        private Mock<ILeagueRepository> _mockLeagueRepository;

        private GameController _gameController;

        private IList<Venue> _venues;
        private IQueryable<Event> _events;
        private IQueryable<Game> _games;
        private IQueryable<Team> _teams;
        private List<League> _leagues;

        public GameControllerTest()
        {
            _mockEventRepository = DataHelper.GetTestEventRepository();
            _mockVenueRepository = DataHelper.GetTestVenueRepository();
            _mockLeagueRepository = DataHelper.GetTestLeagueRepository();
            _mockTeamRepository = DataHelper.GetTestTeamRepository();
            _mockGameRepository = DataHelper.GetTestGameRepository();

            _gameController = new GameController(_mockGameRepository.Object, _mockTeamRepository.Object, _mockEventRepository.Object);

        }

        [Fact]
        public void Index_ReturnsBadRequest_WhenEventIdIsNull()
        {
            //Arrange

            //Act
            var result = _gameController.Index(null);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Index_ReturnsNotFound_WhenEventDoesntExist()
        {
            //Arrange
            //Act
            var result = _gameController.Index(20);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Index_ReturnsViewWithEventGameListViewModel()
        {
            //Arrange

            //Act
            var result = _gameController.Index(1);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<EventGameListViewModel>(viewResult.ViewData.Model);
        }


    }
}
