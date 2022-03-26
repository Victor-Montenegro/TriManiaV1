using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class TriManiaContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }

        public TriManiaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TriManiaContext).Assembly);

            User user = new User("Admin", "admin", "00000000000", "admin@admin.com.br", DateTime.Now);
            user.Id = 1;
            user.SetUserType(UserType.Manager);
            user.EncryptPassword("123456");
            user.CreateDate = DateTime.Now;

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.DeletionDate.HasValue);
        }
    }
}
