using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Editor")]
        public IActionResult GetAll()
        {
            var result = _productDal.GetAll();
            return Ok(result);
        }

        [HttpGet("productid")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _productDal.Get(p => p.ProductId == id);
                if (result == null)
                {
                    return NotFound("No product");
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw new Exception("Hata");
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {

            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {


            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest("Güncellenemedi");

        }

        [HttpPost("delete")]
        public IActionResult Delete(int productid)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productid });
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest("Silinemedi");

        }
        [HttpGet("getproductswithdetail")]
        public IActionResult GetProductsWithDetail()
        {
            try
            {
                var result = _productDal.GetProductsWithDetails();
                return Ok(result);
            }
            catch (Exception)
            {

                throw new Exception("Hata");
            }
            return BadRequest();
        }

    }
}
