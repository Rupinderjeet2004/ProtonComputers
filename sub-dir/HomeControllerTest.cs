using Microsoft.AspNetCore.Mvc;
using ProtonComputers.Controllers;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class HomeControllerTest
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void VerifyAboutViewType()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.About();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
