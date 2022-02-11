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

        // api/products/1
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
    }
}
