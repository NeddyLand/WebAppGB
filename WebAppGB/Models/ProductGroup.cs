namespace WebAppGB.Models
{
    public class ProductGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set;}
    }
}
