namespace WebAppGB.Models
{
    public class Storage
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
