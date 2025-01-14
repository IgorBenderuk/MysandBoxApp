using MySandboxApp.Dal.Entities.Roles;

namespace MySandboxApp.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> ProductsForSale { get; set; }
    }
}
