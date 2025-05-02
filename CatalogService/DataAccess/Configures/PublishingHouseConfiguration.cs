using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.DataAccess.Configures
{
    public class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouseEntity>
    {
        public void Configure(EntityTypeBuilder<PublishingHouseEntity> builder)
        {
            builder.HasKey(x => x.PublishingHouseId);

            builder
                .HasMany(ph => ph.Books)
                .WithOne(b => b.PublishingHouse)
                .HasForeignKey(b => b.BookId);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Books)
                .IsRequired();
        }
    }
}