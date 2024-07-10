using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Abstractions
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroups(int id);
    }
}
