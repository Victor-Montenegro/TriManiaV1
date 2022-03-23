using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappers
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("DECIMAL(15,2)");

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate");

            builder.Property(x => x.DeletionDate)
                .HasColumnName("DeletionDate");

            builder.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);
         
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
