using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappers
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalValue)
                .HasColumnName("TotalValue")
                .HasColumnType("DECIMAL(15,2)");

            builder.Property(x => x.CancelDate)
                .HasColumnName("CancelDate");

            builder.Property(x => x.FinishedDate)
                .HasColumnName("FinishedDate");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.Type)
                .HasColumnName("Type");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreationDate");

            builder.Property(x => x.DeletionDate)
                .HasColumnName("DeletionDate");

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
