using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TriManiaContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }

        public TriManiaContext(DbContextOptions options) : base(options) { }
    }
}
