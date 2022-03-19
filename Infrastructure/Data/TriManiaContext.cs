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

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Login = "admin",
                    Passworld = "BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413",
                    Email = "admin@admin.com.br",
                    Type = UserType.Manager,
                    BirthDay = DateTime.Now,
                    CreateDate = DateTime.Now,
                    Cpf = "00000000000"
                });

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.DeletionDate.HasValue);
        }
    }
}
