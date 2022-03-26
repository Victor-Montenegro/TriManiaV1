using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappers
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Neighborhood)
                .HasColumnName("Neighborhood");

            builder.Property(x => x.Number).
                HasColumnName("Number");

            builder.Property(x => x.State).
                HasColumnName("State");

            builder.Property(x => x.Street).
                HasColumnName("Street");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate");

            builder.Property(x => x.DeletionDate)
                .HasColumnName("DeletionDate");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
