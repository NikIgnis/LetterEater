using CatalogService.Core.Models;
using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.DataAccess.Configures
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.BookId);

            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder
                .HasOne(b => b.PublishingHouse)
                .WithMany(ph => ph.Books)
                .HasForeignKey(b => b.PublishingHouseId);

            builder.Property(x => x.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(x => x.AuthorName)
                .IsRequired();

            builder.Property(x => x.PublicationYear)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Book.MAX_DESCRIPTIONLENGTH)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.CountPages)
                .IsRequired();

            builder.Property(x => x.PublishingHouseName)
                .IsRequired();

            builder.Property(x => x.ISBN)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();
        }
    }
}