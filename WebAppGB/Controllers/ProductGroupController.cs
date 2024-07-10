using Microsoft.AspNetCore.Mvc;
using WebAppGB.Data;
using WebAppGB.Models;

namespace WebAppGB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProductGroup(string name, string description)
        {
            using (Context context = new Context())
            {
                if (context.ProductGroups.Any(p => p.Name == name))
                {
                    return StatusCode(409);
                }
                var productGroup = new ProductGroup { Name = name, Description = description };
                context.ProductGroups.Add(productGroup);
                context.SaveChanges();
                return Ok(productGroup.ID);
            }
        }
        [HttpGet]
        public ActionResult GetProductGroups()
        {
            using (Context context = new Context())
            {
                var productGroup = context.ProductGroups.Select(p => new ProductGroup { Name = p.Name, Description = p.Description}).ToList();
                return Ok(productGroup);
            }
        }
        [HttpDelete]
        public ActionResult DeleteProductGroups(int id)
        {
            using (Context context = new Context())
            {
                ProductGroup productGroup = context.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return NotFound();
                }
                context.ProductGroups.Remove(productGroup);
                context.SaveChanges();
                return Ok($"Товарная группа {productGroup.Name} удалена");
            }
        }
    }
}
