using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappers
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("DECIMAL(15,2)");

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate");

            builder.Property(x => x.DeletionDate)
                .HasColumnName("DeletionDate");
        }
    }
}
