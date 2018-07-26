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
        public class Index
        {
            [Fact]
            public void ReturnsViewResult()
            {
                var mockRepository= new Mock<IEventRepository>();
                var sut = new HomeController(mockRepository.Object);
            
                var result = sut.Index();

                Assert.IsType<ViewResult>(result);

            }
        }
        public class Details
        {

            [Fact]
            public void ReturnsNotFoundResult()
            {
                //passing an id to Details with no corresponding event 
                // should return not found
                var mockRepository= new Mock<IEventRepository>();
                var sut = new HomeController(mockRepository.Object);
                var result = sut.Details(1);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsViewResult()
            {
                //this time set up populated repository
                IList<Event> events = new List<Event>
                {
                    new Event {Id=1,Name="Event Name 1", EventDate="20180714",Description="MRDA Tier 1 North Playoffs",Cancelled = false,VenueId = 1},
                    new Event {Id=2,Name="Event Name 2", EventDate="20180714",Description="Friendly match",Cancelled = false,VenueId = 1},
                    new Event {Id=3,Name="Event Name 3", EventDate="20180714",Description="Friendly match",Cancelled = false,VenueId = 2},
                    new Event {Id=4,Name="Event Name 4", EventDate="20180714",Description="MRDA Tier 3 South Playoffs",Cancelled = false,VenueId = 1},
                    new Event {Id=5,Name="Event Name 5", EventDate="20180714",Description="MRDA Tier 2 North Playoffs",Cancelled = false,VenueId = 2}

                };

                //Mock the event repository
                Mock<IEventRepository> mockEventRepository = new Mock<IEventRepository>();
                //Return all events
                mockEventRepository.Setup(mr => mr.GetAllEvents()).Returns(events);
                mockEventRepository.Setup(mr => mr.GetEventById(
                    It.IsAny<int>())).Returns((int i) => events.Where(
                    x => x.Id == i).Single());

                var MockEventRepository = mockEventRepository.Object;

                Event testEvent = MockEventRepository.GetEventById(1);
                Assert.NotNull(testEvent);
                Assert.IsType<Event>(testEvent);
                Assert.Equal("Event Name 1",testEvent.Name);


            }
        }
    }
}
