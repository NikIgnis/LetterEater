using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Configures
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