using System.Collections.Generic;
using System.Linq;
using LrMetadataBuilder.Controllers;
using LrMetadataBuilder.Models;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using lrMetadataBuilderTest.Utilities;


namespace lrMetadataBuilderTest.Controllers
{
    public class LeagueControllerTest : Controller
    {
        private Mock<ILeagueRepository> _mockLeagueRepository;
        private LeagueController _leagueController;

        public LeagueControllerTest()
        {
            _mockLeagueRepository = DataHelper.GetTestLeagueRepository();
            _leagueController = new LeagueController(_mockLeagueRepository.Object);
        }

        [Fact]
        public void Index_ReturnsLeagueViewModel()
        {
            //Arrange

            //Act
            var result = _leagueController.Index();

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<LeagueViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Details_ReturnsBadRequest_WhenNoIdProvided()
        {
            //Arrange

            //Act
            var result = _leagueController.Details(null);

            //Assert
            Assert.NotNull(result);
            var viewModel = Assert.IsAssignableFrom<BadRequestResult>(result);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenLeagueDoesntExist()
        {
            //Arrange

            //Act
            var result = _leagueController.Details(20);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]

        public void Details_ReturnsLeagueViewModelView_WhenLeagueExists()
        {
            //Arrange

            //Act
            var result = _leagueController.Details(1);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<LeagueViewModel>(viewResult.ViewData.Model);

        }

        [Fact]
        public void Create_ReturnsLeagueViewModelView()
        {
            //Arrange

            //Act
            var result = _leagueController.Create();
            
            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<LeagueViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_ReturnsLeagueViewModelCreate_WhenModelIsNotValid()
        {
            //Arrange
            var leagueViewModel = new LeagueViewModel();
            _leagueController.ModelState.AddModelError("Name","Required");

            //Act
            var result = _leagueController.Create(leagueViewModel);

            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<LeagueViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_ReturnsRedirectToIndex_WhenModelIsValid()
        {
            //Arrange
            var leagueViewModel = new LeagueViewModel();
            
            //Act
            var result = _leagueController.Create(leagueViewModel);

            //Assert
            Assert.NotNull(result);
            var redirectResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            
            

            
        }

    }
}
