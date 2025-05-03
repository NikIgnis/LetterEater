using CatalogService.Core.Models;

namespace CatalogService.Core.Abstractions
{
    public interface IPublishingHousesRepository
    {
        Task<Guid> Create(PublishingHouse publishingHouse);
        Task<Guid> Delete(Guid publishingHouseId);
        Task<List<PublishingHouse>> Get();
        Task<Guid> Update(Guid publishingHouseId, string name, List<Guid> booksId);
    }
}