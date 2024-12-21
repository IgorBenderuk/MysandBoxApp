using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySandboxApp.Dal.Entities;
using MySandboxApp.Dal.Options;

namespace MySandboxApp.Dal
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<DbOptions> dbOptions) : base(options)
        {
            _connectionString = dbOptions.Value.DefaultConnection;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
