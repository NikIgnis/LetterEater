using LetterEater.Core.Models;
using LetterEater.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
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

        public async Task<Guid> UpdatePublishingHouse(Guid publishingHouseId, string name, List<Book> books)
        {
            return await _publishingHousesRepository.Update(publishingHouseId, name, books);
        }

        public async Task<Guid> DeletePublishing(Guid publishingHouseId)
        {
            return await _publishingHousesRepository.Delete(publishingHouseId);
        }
    }
}