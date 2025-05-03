using CatalogService.Core.Models;

namespace CatalogService.Core.Abstractions
{
    public interface IPublishingHousesService
    {
        Task<Guid> CreatePublishingHouse(PublishingHouse publishingHouse);
        Task<Guid> DeletePublishing(Guid publishingHouseId);
        Task<List<PublishingHouse>> GetPublishingHouses();
        Task<Guid> UpdatePublishingHouse(Guid publishingHouseId, string name, List<Guid> booksId);
    }
}