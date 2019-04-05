using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Event.Controllers;
using Event.Models;
using System.Collections.Generic;
using System.Linq;

namespace Event.Tests.Controllers
{

    [TestClass]
    public class EventDetailsControllerTest
    {
        // moq data
        EventDetailsController controller;
        List<EventDetail> eventDetail;
        Mock<IMockEventDetails> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            eventDetail = new List<EventDetail>
            {
                new EventDetail { IdNumber = 100, Name = "FLying monkey" },
                new EventDetail { IdNumber = 102, Name = "Fireworks" },
                new EventDetail { IdNumber = 103, Name = "Winter Fest" }
            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockEventDetails>();
           // mock.Setup(e => e.EventDetails).Returns(eventDetail.AsQueryable());

            // initialize the controller and inject the mock object
           // controller = new EventDetailsController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // arrange
            // now handled in TestInitialize

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsCategories()
        {
            // act
            // call the index method
            // access the data model returned to the view
            // cast the data as a list of type Category
            var results = (List<EventDetail>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(eventDetail.OrderBy(e => e.Name).ToList(), results);
        }


    }
}
