using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;

namespace CatalogService.Application.Services
{
    public class PublishingHousesService : IPublishingHousesService
    {
        private readonly IPublishingHousesRepository _publishingHousesRepository;

        public PublishingHousesService(IPublishingHousesRepository publishingHousesRepository)
        {
            _publishingHousesRepository = publishingHousesRepository;
        }

        public async Task<Guid> CreatePublishingHouse(PublishingHouse publishingHouse)
        {
            return await _publishingHousesRepository.Create(publishingHouse);
        }

        public async Task<List<PublishingHouse>> GetPublishingHouses()
        {
            return await _publishingHousesRepository.Get();
        }

        public async Task<Guid> UpdatePublishingHouse(Guid publishingHouseId, string name, List<Guid> booksId)
        {
            return await _publishingHousesRepository.Update(publishingHouseId, name, booksId);
        }

        public async Task<Guid> DeletePublishing(Guid publishingHouseId)
        {
            return await _publishingHousesRepository.Delete(publishingHouseId);
        }
    }
}