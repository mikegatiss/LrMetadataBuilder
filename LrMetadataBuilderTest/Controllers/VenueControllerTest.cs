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

namespace lrMetadataBuilderTest
{
    public class VenueControllerTest
    {

        [Fact]
        public void Index_ReturnsAViewResult_WithListOfVenues()
        {
            // Arrange
            var mockRepo = new MockVenueRepository();

            var controller = new VenueController(mockRepo);

        }
    }
}
