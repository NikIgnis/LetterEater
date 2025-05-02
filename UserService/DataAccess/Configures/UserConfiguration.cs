using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Core.Models;
using UserService.DataAccess.Entities;

namespace UserService.DataAccess.Configures
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Name)
                .HasMaxLength(User.MAX_LENGTH_NAME_SURENAME)
                .IsRequired();

            builder.Property(x => x.Surename)
                .HasMaxLength(User.MAX_LENGTH_NAME_SURENAME)
                .IsRequired();

            builder.Property(x => x.Login)
                .HasMaxLength(User.MAX_LENGTH_LOGIN)
                .IsRequired();

            builder.Property(x => x.ContactNumber)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(User.MAX_LENGTH_PASSWORD)
                .IsRequired();
        }
    }
}