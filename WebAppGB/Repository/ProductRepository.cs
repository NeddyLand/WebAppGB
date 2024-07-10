using AutoMapper;
using WebAppGB.Abstractions;
using WebAppGB.Data;
using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Repository
{
    public class ProductRepository : IProductRepository
    {
        Context context = new Context();
        private readonly IMapper _mapper;
        public ProductRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }
        public int AddProduct(ProductDto productDto)
        {
            if (context.Products.Any(p => p.ProductName == productDto.ProductName))
            {
                throw new Exception("Продукт с таким именем уже существует.");
            }
            var entity = _mapper.Map<Product>(productDto);
            context.Products.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var listDto = context.Products.Select(_mapper.Map<ProductDto>).ToList();
            return listDto;
        }
    }
}
