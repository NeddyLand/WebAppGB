using WebAppGB.Models;

namespace WebAppGB.Dto
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? ProductGroupID { get; set; }
    }
}
