using LetterEater.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Configures
{
    public class PublishingHouseConfigure : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(x => x.PublishingHouseId);

            builder
                .HasMany(ph => ph.Books)
                .WithOne(b => b.PublishingHouse)
                .HasForeignKey(b => b.PublishingHouseId);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Books)
                .IsRequired();
        }
    }
}
