using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);

    }
}
