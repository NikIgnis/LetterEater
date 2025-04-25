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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.HasKey(ci => ci.CartItemId);

            builder
                .HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(u => u.UserId);

            builder
                .HasOne(ci => ci.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(b => b.BookId);

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.Price)
                .IsRequired();
        }
    }
}