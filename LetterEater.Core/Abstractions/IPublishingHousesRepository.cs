using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IPublishingHousesRepository
    {
        Task<Guid> Create(PublishingHouse publishingHouse);
        Task<Guid> Delete(Guid publishingHouseId);
        Task<List<PublishingHouse>> Get();
        Task<Guid> Update(Guid publishingHouseId, string name, List<Guid> booksId);
    }
}