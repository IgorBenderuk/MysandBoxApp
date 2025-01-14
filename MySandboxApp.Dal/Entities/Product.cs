namespace MySandboxApp.Dal.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
