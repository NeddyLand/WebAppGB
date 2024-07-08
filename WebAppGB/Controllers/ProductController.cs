using Microsoft.AspNetCore.Mvc;
using WebAppGB.Data;
using WebAppGB.Models;

namespace WebAppGB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProduct(string name, string description, decimal price) 
        {
            using(Context context = new Context())
            {
                if (context.Products.Any(p => p.ProductName == name)) 
                {
                    return StatusCode(409);
                }
                var product = new Product { ProductName = name, Description = description, Price = price };
                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product.ID);
            }
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            using(Context context = new Context()) 
            { 
                var products = context.Products.Select(p => new Product { ProductName = p.ProductName, Description = p.Description, Price = p.Price}).ToList();
                return Ok(products);
            }
        }
    }
}
