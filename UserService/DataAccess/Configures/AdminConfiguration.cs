using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Core.Models;
using UserService.DataAccess.Entities;

namespace UserService.DataAccess.Configures
{
    public class AdminConfiguration : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> builder)
        {
            builder.HasKey(x => x.AdminId);

            builder.Property(x => x.Name)
                .HasMaxLength(Admin.MAX_LENGTH_NAME_SURENAME)
                .IsRequired();

            builder.Property(x => x.Surename)
                .HasMaxLength(Admin.MAX_LENGTH_NAME_SURENAME)
                .IsRequired();

            builder.Property(x => x.ContactNumber)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(Admin.MAX_LENGTH_PASSWORD)
                .IsRequired();
        }
    }
}