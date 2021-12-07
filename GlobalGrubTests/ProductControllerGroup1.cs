using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalGrub.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalGrub.Data;
using GlobalGrub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GlobalGrubTest
{
    [TestClass]
    public class ProductControllerTestGroup1
    {
        // class level variables shared by all tests
        private ApplicationDbContext _context;
        ProductsController controller;
        List<Product> products = new List<Product>();

        // this runs automatically before each test
        [TestInitialize]
        public void TestInitialize()
        {
            // create in-menory db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // populate db with mock data
            var category = new Category
            {
                CategoryId = 500,
                Name = "Favorite Food"
            };
            _context.Categories.Add(category);

            products.Add(new Product
            {
                ProductId = 750,
                Name = "Pizza",
                Price = 20,
                CategoryId = 500,
                Category = category
            });

            products.Add(new Product
            {
                ProductId = 751,
                Name = "Sushi",
                Price = 12,
                CategoryId = 500,
                Category = category
            });

            products.Add(new Product
            {
                ProductId = 752,
                Name = "Chicago Style",
                Price = 15,
                CategoryId = 500,
                Category = category
            });

            products.Add(new Product
            {
                ProductId = 753,
                Name = "fried chicken",
                Price = 7,
                CategoryId = 500,
                Category = category
            });


            foreach (var product in products)
            {
                _context.Products.Add(product);
            }
            _context.SaveChanges();

            // instanciate controller with db dependency
            controller = new ProductsController(_context);
        }

        #region Create
        // Create (GET)
        [TestMethod]
        public void IndexLoadsCreateView()
        {
            // act 
            var result = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateViewDataPopulated()
        {
            // act 
            var result = (ViewResult)controller.Create();

            // assert
            Assert.IsNotNull(result.ViewData["CategoryId"]);
        }
        #endregion

        #region Edit
        // Edit (GET)
        [TestMethod]
        public void IndexLoadsEditView()
        {
            // act 
            var result = (ViewResult)controller.Edit(products[1].ProductId).Result;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsProduct()
        {
            // act
            var result = (ViewResult)controller.Edit(products[1].ProductId).Result;

            //assert
            Assert.AreEqual(products[1], result.Model);
        }

        [TestMethod]
        public void EditViewDataPopulated()
        {
            // act 
            var result = (ViewResult)controller.Edit(products[1].ProductId).Result;

            // assert
            Assert.IsNotNull(result.ViewData["CategoryId"]);
        }

        [TestMethod]
        public void EditInValidIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Edit(1000).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void EditNullIdLoads404()
        {
            // act 
            var result = (ViewResult)controller.Edit(null).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }
        #endregion
    }
}