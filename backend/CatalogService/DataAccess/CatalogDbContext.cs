using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublishingHouseEntity> PublishingHouses { get; set; }
    }
}