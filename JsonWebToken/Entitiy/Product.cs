namespace JsonWebToken.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
