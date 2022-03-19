using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<TriManiaContext>
    {
        public TriManiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=TriManiaV1;Integrated Security=true";
            var optionsBuilder = new DbContextOptionsBuilder<TriManiaContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new TriManiaContext(optionsBuilder.Options);
        }
    }
}
