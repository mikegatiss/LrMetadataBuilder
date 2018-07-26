using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LrMetadataBuilder.Controllers;
using LrMetadataBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace lrMetadataBuilderTest.Controllers
{
    public class HomeControllerTest
    {
        private readonly Mock<IEventRepository> _mockRepository;
        private readonly HomeController _sut;


        public HomeControllerTest()
        {
            _mockRepository = new Mock<IEventRepository>();
            _sut = new HomeController(_mockRepository.Object);

        }

        public class Index
        {
            [Fact]
            public void ReturnsViewResult()
            {
                IActionResult result = _sut.Index();

                Assert.IsType<ViewResult>(result);

            }
        }
    }
}
