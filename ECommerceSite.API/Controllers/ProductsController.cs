using ECommerceSite.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSite.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products = new List<Product>
        {
            new Product(1, "Chinelo", 10),
            new Product(2, "Tempero", 5),
            new Product(3, "Bicicleta", 50),
        };

       [HttpGet]
       public IActionResult Get()
        {
            return Ok(_products);
        }
    }
}
