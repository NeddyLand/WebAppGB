using Microsoft.AspNetCore.Mvc;
using WebAppGB.Abstractions;
using WebAppGB.Data;
using WebAppGB.Dto;
using WebAppGB.Models;
using WebAppGB.Repository;

namespace WebAppGB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _productGroupRepository;
        public ProductGroupController(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }
        [HttpPost]
        public ActionResult<int> AddProductGrpoup(ProductGroupDto productGroupDto)
        {
            try
            {
                int id = _productGroupRepository.AddProductGroup(productGroupDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
        }
        [HttpGet]
        public ActionResult GetProductGroups()
        {
            var list = _productGroupRepository.GetProductGroups;
            return Ok(list);
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
