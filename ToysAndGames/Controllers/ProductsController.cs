using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames_DataAccess.Contracts;
using ToysAndGames_DataAccess.Repository;
using ToysAndGames_Models.Models;

namespace ToysAndGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IProductRepository repo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _unitOfWork.ProductRepository.FindAll();
            
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var exists = await _unitOfWork.ProductRepository.isExists(c => c.Product_Id == id);
            if (!exists)
            {
                return NotFound();
            }
            var product = await _unitOfWork.ProductRepository.Find(c=> c.Product_Id == id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.ProductRepository.Create(product);
            await _unitOfWork.Save();
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Product product)
        {
            try
            {
                var exists = await _unitOfWork.ProductRepository.isExists(c => c.Product_Id == product.Product_Id);
                if (!exists)
                {
                    return NotFound();
                }

                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.Save();
                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Product_Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int Product_Id)
        {
            var exists = await _unitOfWork.ProductRepository.isExists(c => c.Product_Id == Product_Id);
            if (!exists)
            {
                return NotFound();
            }
            var ProductToDelete = await _unitOfWork.ProductRepository.Find(c => c.Product_Id == Product_Id);
            _unitOfWork.ProductRepository.Delete(ProductToDelete);
            await _unitOfWork.Save();
            return Ok(true);
        }
    }
}
