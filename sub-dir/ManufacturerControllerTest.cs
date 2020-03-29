using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtonComputers.Controllers;
using ProtonComputers.Data;
using ProtonComputers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ProtonComputerTests
{
    public class ManufacturerControllerTest
    {
        //Dependency injection
        private ApplicationDbContext _context;
        ManufacturersController manufacturersController;
        List<Manufacturers> manufacturers = new List<Manufacturers>();
        List<Products> products = new List<Products>();

        [Fact(DisplayName = "Inserting data to manufacturers table.")]
        public ApplicationDbContext Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            products.Add(new Products
            {
                ManufacturerID = 3,
                ProductID = 5,
                ProductName = "Origin Desktop",
                ProductDescription = "Just Desktop PC",
                Price = 2000
            });

            products.Add(new Products
            {
                ManufacturerID = 4,
                ProductID = 6,
                ProductName = "MSI PS63 Modern 8RC",
                ProductDescription = "My Laptop :) i7 8565U, 16GB DDR4, NVIDIA® GeForce GTX™ 1050 MaxQ GDDR6 4GB",
                Price = 2100
            });

            products.Add(new Products
            {
                ManufacturerID = 5,
                ProductID = 7,
                ProductName = "Aorus 17",
                ProductDescription = "i9 9980K, 64GB DDR4, NVIDIA® GeForce RTX™ 2080 GDDR6 8GB",
                Price = 2100
            });
            //Act
            manufacturers.Add(new Manufacturers
            {
                ManufacturerID = 3,
                ManufacturerName = "OriginPc",
                WebsiteName = "www.originpc.com",
                //yyyy.mm,dd,hh,mm,ss,ms
                Founded = new DateTime(2020, 03, 21, 21, 30, 12, 121),
                ProductList = products
            });

            manufacturers.Add(new Manufacturers
            {
                ManufacturerID = 4,
                ManufacturerName = "MSI",
                WebsiteName = "www.msi.com",
                //yyyy.mm,dd,hh,mm,ss,ms
                Founded = new DateTime(2020, 03, 21, 21, 30, 12, 121),
                ProductList = products
            });

            manufacturers.Add(new Manufacturers
            {
                ManufacturerID = 5,
                ManufacturerName = "Aorus",
                WebsiteName = "www.aorus.com",
                //yyyy.mm,dd,hh,mm,ss,ms
                Founded = new DateTime(2020, 03, 21, 21, 30, 12, 121),
                ProductList = products
            });

            foreach (var m in manufacturers)
            {
                _context.Manufacturers.Add(m);
            }

            _context.SaveChanges();

            //Assert
            manufacturersController = new ManufacturersController(_context);
            return _context;
        }

        [Fact(DisplayName = "Index should return default view.")]
        public async void Index_should_return_default_view()
        {
            //Arrange
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                //Act
                var result = await controller.Index() as ViewResult;

                //Assert
                Assert.NotNull(result);
                Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
        }

        [Fact(DisplayName = "Index should return manufacturer list.")]
        public async void Index_should_return_manufacturer_list()
        {
            //Arrange
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                //Act
                var result = await controller.Index() as ViewResult;

                //Assert
                Assert.Equal(manufacturers.OrderBy(m => m.ManufacturerID).ToList(), (List<Manufacturers>)result.Model);
            }
        }

        [Fact(DisplayName = "Index should return valid model.")]
        public async void Index_should_return_valid_model()
        {
            //Arrange
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                //Act
                ViewResult result = await controller.Index() as ViewResult;
                var model = (List<Manufacturers>)result.ViewData.Model;
                //Assert
                Assert.NotNull(model);
            }
        }

        [Fact(DisplayName = "Details Should return 404 Not Found Error if Id is missing in Details method.")]
        public void Details_Should_return_404Not_Found_Error_if_Id_is_missing_in_Details_method()
        {
            //Arrange
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                // Act
                var result = controller.Details(null).Result as NotFoundResult;

                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact(DisplayName = "Details should return 404 Not Found Error if Id is wrong.")]
        public void Details_Should_return_404Not_Found_Error_if_Id_is_wrong()
        {
            //Arrange
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                //Act
                var res = controller.Details(55).Result as NotFoundResult;

                //Assert
                Assert.NotNull(res);
            }
        }

        [Fact(DisplayName = "Details should return data based on id.")]
        public async void Details_should_return_data_based_on_id()
        {
            //Arraneg
            using (var _context = Adding_Manufacturers_To_Database_To_Test_If_It_Works_Or_Not())
            using (var controller = new ManufacturersController(_context))
            {
                //Act
                ViewResult res = await controller.Details(5) as ViewResult;
                //Assert
                Assert.Equal(manufacturers[2], res.Model);
            }
        }

    }
}
