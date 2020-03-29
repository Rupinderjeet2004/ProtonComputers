using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtonComputers.Controllers;
using ProtonComputers.Data;
using ProtonComputers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProtonComputerTests
{
    public class ProductsControllerTest
    {
        //Dependency injection
        private ApplicationDbContext _context;
        ProductsController productsController;
        List<Products> products = new List<Products>();

        Manufacturers manufacturersMock = new Manufacturers
        {
            ManufacturerID = 3,
            ManufacturerName = "OriginPc",
            WebsiteName = "www.originpc.com",
            //yyyy.mm,dd
            Founded = new DateTime(2020, 03, 21, 21, 30, 12, 121)
        };

        [Fact(DisplayName = "Inserting Data to Products Table")]
        public ApplicationDbContext Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);


            //Act
            products.Add(new Products
            {
                ManufacturerID = manufacturersMock.ManufacturerID,
                ProductID = 5,
                ProductName = "Origin Desktop",
                ProductDescription = "Just Desktop PC",
                Price = 2000
            });

            products.Add(new Products
            {
                ManufacturerID = manufacturersMock.ManufacturerID,
                ProductID = 6,
                ProductName = "MSI PS63 Modern 8RC",
                ProductDescription = "My Laptop :) i7 8565U, 16GB DDR4, NVIDIA® GeForce GTX™ 1050 MaxQ GDDR6 4GB",
                Price = 2100
            });

            products.Add(new Products
            {
                ManufacturerID = manufacturersMock.ManufacturerID,
                ProductID = 7,
                ProductName = "Aorus 17",
                ProductDescription = "i9 9980K, 64GB DDR4, NVIDIA® GeForce RTX™ 2080 GDDR6 8GB",
                Price = 2100
            });

            foreach (var p in products)
            {
                _context.Add(p);
            }

            _context.SaveChanges();

            //Assert
            productsController = new ProductsController(_context);
            return _context;
        }

        [Fact(DisplayName = "Index should return default view")]
        public async void Index_should_return_default_view()
        {
            //Arrange
            using (var context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(context))
            {
                //Act
                var result = await controller.Index() as ViewResult;

                //Assert
                Assert.NotNull(result);
                Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
        }

        /*Index should return products list.
         *I dont know how to iterate over this Sorry. Would love the explanation. 👏
        [Fact(DisplayName = "Index should return products list.")]
        public async void Index_should_return_products_list()
        {

            using (var _context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(_context))
            {
                var result = await controller.Index() as ViewResult;

                Assert.Equal(products.OrderBy(m => m.ProductID).ToList(), (List<Products>)result.Model);
            }
        }
        */

        [Fact(DisplayName = "Index should return valid model")]
        public async void Index_should_return_valid_model()
        {
            //Arrange
            using (var _context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(_context))
            {
                //Act
                ViewResult result = await controller.Index() as ViewResult;
                var model = (List<Products>)result.ViewData.Model;

                //Assert
                Assert.NotNull(model);
            }
        }

        [Fact(DisplayName = "Details Should return 404 Not Found Error if Id is missing in Details method.")]
        public void Details_Should_return_404Not_Found_Error_if_Id_is_missing_in_Details_method()
        {
            //Arrange
            using (var _context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(_context))
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
            using (var _context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(_context))
            {
                //Act
                var res = controller.Details(55).Result as NotFoundResult;
                //Assert
                Assert.NotNull(res);
            }
        }

        /*Details should return data based on id
         * Don't know how to cmoplete this one. Would love the explanation how to do this. 👏
         * 
        [Fact(DisplayName = "Details should return data based on id")]

        public async void Details_should_return_data_based_on_id()
        {
            using (var _context = Adding_Products_To_Database_According_To_ManufactuerID_To_Test_If_It_Works_Or_Not())
            using (var controller = new ProductsController(_context))
            {
                // ViewResult res = await controller.Details(5) as ViewResult;

                //Assert.Equal(manufacturers[2], res.Model);
                var newVar = controller.Details(5).Result as ViewResult;
                //var res = await controller.Details(5);
                var temp = await _context.Products.Include(p => p.Manufacturers).FirstOrDefaultAsync(m => m.ProductID.Equals(newVar));
                Assert.Equal(temp, newVar.Model);
            }
        }
        */
    }
}
