using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using WebAppGB.Abstractions;
using WebAppGB.Data;
using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Repository
{
    public class ProductRepository(Context _context, IMapper _mapper, IMemoryCache _memoryCache) : ControllerBase, IProductRepository
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

        private string GetCSV(IEnumerable<ProductDto> listDto)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in listDto) 
            {
                sb.Append(item.ProductName + ";" + item.Description + ";" + item.Price + "\n");
            }
            return sb.ToString();
        }

        [HttpGet(template:"GetProductsCSV")]
        public FileContentResult GetProductsCSV()
        {
            var products = _context.Products.Select(_mapper.Map<ProductDto>).ToList();
            var content = GetCSV(products);
            return File(new System.Text.UTF8Encoding().GetBytes(content), "test/csv", "report.csv");
        }
    }
}
