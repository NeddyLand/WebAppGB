using AutoMapper;
using WebAppGB.Abstractions;
using WebAppGB.Data;
using WebAppGB.Dto;
using WebAppGB.Models;

namespace WebAppGB.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        Context context = new Context();
        private readonly IMapper _mapper;
        public ProductGroupRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }
        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (context.Products.Any(p => p.ProductName == productGroupDto.Name))
            {
                throw new Exception("Товарная группа с таким именем уже существует.");
            }
            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            context.ProductGroups.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public void DeleteProductGroups(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupDto> GetProductGroups()
        {
            var listDto = context.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
        }
    }
}
