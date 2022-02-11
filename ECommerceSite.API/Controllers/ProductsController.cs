using ECommerceSite.API.Models;
using ECommerceSite.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerceSite.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ECommerceDbContext _ecommerceDbContext;

        public ProductsController(ECommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }

        // api/products HTTP Get
        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDbContext.Products.ToList();
            return Ok(products);
        }

        // api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
            
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] ProductInputModel productInputModel)
        {

            if(productInputModel == null)
            {
                return BadRequest();
            }

            var prod = new Product(productInputModel.Description, productInputModel.Price);

            _ecommerceDbContext.Products.Add(prod);
            _ecommerceDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = prod.Id}, prod);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductInputModel productInputModel, int id)
        {
            if(productInputModel == null)
            {
                return BadRequest();
            }
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            product.Description = productInputModel.Description;
            product.Price = productInputModel.Price;

            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            _ecommerceDbContext.Products.Remove(product);
            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }
    }
}
