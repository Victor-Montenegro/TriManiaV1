using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappers
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
                .HasColumnName("Login");
            
            builder.Property(x => x.Email)
                .HasColumnName("Email");
            
            builder.Property(x => x.Cpf)
                   .HasColumnName("CPF");
            
            builder.Property(x => x.BirthDay)
                .HasColumnName("BirthDay");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreationDate");

            builder.Property(x => x.DeletionDate)
                .HasColumnName("DeletionDate");

            builder.Property(x => x.Type)
                .HasColumnType("TINYINT")
                .HasColumnName("Type");

        }
    }
}
