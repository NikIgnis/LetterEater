using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.DataAccess.Entities;

namespace LetterEater.DataAccess.Configures
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.HasKey(ci => ci.CartItemId);

            builder.Property(ci => ci.UserId)
                .IsRequired();

            builder.Property(ci => ci.BookId)
                .IsRequired();

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.Price)
                .IsRequired();
        }
    }
}