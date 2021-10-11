using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Controllers;
using Moq;
using ToysAndGames_DataAccess.Contracts;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames_Models.Models;
using ToysAndGames_DataAccess.Repository;

namespace ToysAndGames.Tests
{
    public class ProductsTest
    {
        private readonly ProductsController _controller;
        private readonly Mock<IProductRepository> _repo;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ProductRepository> _pRepo;
        public ProductsTest()
        {
            _repo = new Mock<IProductRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _controller = new ProductsController(_repo.Object,_unitOfWork.Object);
        }

        [Fact]
        public void Get_ReturnAllProducts()
        {
            var result = _controller.Get();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<Task<ActionResult>>(result);
            Assert.IsType<Task<ActionResult>>(result);
        }

        [Fact]
        public void Post_ReturnBadRequestProductSaved()
        {
            _controller.ModelState.AddModelError("Test", "Test");
            var result = _controller.Create(new Product
            {
                Product_Id = 1,
                Name = "Scrabble",
                Description = "Word Game",
                AgeRestriction = 99,
                Company = "Mattel",
                Price = 99.99m
            });
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void Post_ReturnOkProductSaved()
        {
            var prod = new Product()
            {
                Product_Id = 10,
                Name = "Scrabble",
                Description = "Word Game",
                AgeRestriction = 99,
                Company = "Mattel",
                Price = 99.99m
            };

            var result = _controller.Create(prod);

            Assert.IsType<OkResult>(result.Result);
        }
    }
}
