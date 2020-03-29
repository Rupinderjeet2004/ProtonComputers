using Microsoft.AspNetCore.Mvc;
using ProtonComputers.Controllers;
using Xunit;

namespace ProtonComputerTests
{

    public class HomeControllerTest
    {
        // private HomeController _context;

        [Fact(DisplayName = "Index should return default view")]
        public void Index_should_return_default_view()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

        }

        [Fact(DisplayName = "About should return default view")]
        public void About_should_return_default_view()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.About() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "About");

        }

    }
}
