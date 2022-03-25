using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<TriManiaContext>
    {
        public TriManiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;port=3306;Database=TriManiaV1;user=root;Password=123456";
            var optionsBuilder = new DbContextOptionsBuilder<TriManiaContext>();

            //optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.UseMySql(connectionString);

            return new TriManiaContext(optionsBuilder.Options);
        }
    }
}
