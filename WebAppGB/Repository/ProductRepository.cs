using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebAppGB.Abstractions;
using WebAppGB.Data;
using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Repository
{
    public class ProductRepository(Context _context, IMapper _mapper, IMemoryCache _memoryCache) : IProductRepository
    {
        public int AddProduct(ProductDto productDto)
        {
            if (_context.Products.Any(p => p.ProductName == productDto.ProductName))
            {
                throw new Exception("Продукт с таким именем уже существует.");
            }
            var entity = _mapper.Map<Product>(productDto);
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity.ID;
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto))
            {
                return listDto;
            }
            listDto = _context.Products.Select(_mapper.Map<ProductDto>).ToList();
            _memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));
            return listDto;
        }
    }
}
