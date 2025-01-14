using MySandboxApp.Dal.Entities.Roles;

namespace MySandboxApp.Dal.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public long TotalCost { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
