﻿using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LetterEater.DataAccess.Configures
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.BookId);

            builder.Property(x => x.Author)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGTH)
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

            builder.Property(x => x.PublishingHouse)
                .IsRequired();

            builder.Property(x => x.ISBN)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired();
        }
    }
}