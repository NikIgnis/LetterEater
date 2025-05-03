using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;
using CatalogService.DataAccess;
using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetterEater.DataAccess.Repositories
{
    public class PublishingHousesRepository : IPublishingHousesRepository
    {
        private readonly CatalogDbContext _context;

        public PublishingHousesRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(PublishingHouse publishingHouse)
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync(b => b.PublishingHouseId == publishingHouse.PublishingHouseId);

            if (publishingHouseExist)
            {
                throw new Exception("Publishing house is available!");
            }

            var publishingHouseEntity = new PublishingHouseEntity()
            {
                PublishingHouseId = publishingHouse.PublishingHouseId,
                Name = publishingHouse.Name,
                BooksId = new List<Guid>(publishingHouse.BooksId)
            };

            await _context.PublishingHouses.AddAsync(publishingHouseEntity);
            await _context.SaveChangesAsync();

            return publishingHouse.PublishingHouseId;
        }

        public async Task<List<PublishingHouse>> Get()
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync();

            if (!publishingHouseExist)
            {
                throw new Exception("Publishing houses don't available");
            }

            var publishingHouseEntity = await _context.PublishingHouses
                .AsNoTracking()
                .ToListAsync();

            var publishingHouse = publishingHouseEntity
                .Select(a => PublishingHouse.Create(
                a.PublishingHouseId,
                a.Name,
                new List<Guid>(a.BooksId)
                ))
                .ToList();

            return publishingHouse;
        }

        public async Task<Guid> Update(Guid publishingHouseId, string name, List<Guid> booksId)
        {
            bool publishingHouseExists = await _context.PublishingHouses
                .AnyAsync(b => b.PublishingHouseId == publishingHouseId);

            if (!publishingHouseExists)
            {
                throw new Exception("Publishing house doesn't exist!");
            }

            await _context.PublishingHouses
                .Where(a => a.PublishingHouseId == publishingHouseId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, name)
                    .SetProperty(b => b.BooksId, new List<Guid>(booksId)));
                    
            return publishingHouseId;
        }

        public async Task<Guid> Delete(Guid publishingHouseId)
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync(b => b.PublishingHouseId == publishingHouseId);

            if (!publishingHouseExist)
            {
                throw new Exception("Publishing house doesn't exist!");
            }

            await _context.PublishingHouses
                .Where(b => b.PublishingHouseId == publishingHouseId)
                .ExecuteDeleteAsync();

            return publishingHouseId;
        }
    }
}