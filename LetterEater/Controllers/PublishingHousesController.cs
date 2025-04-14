using LetterEater.Application.Services;
using LetterEater.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LetterEater.Controllers
{
    [ApiController]
    [Route("api/PublishingHouses/[controller]")]
    public class PublishingHousesController : ControllerBase
    {
        private readonly IPublishingHousesService _publishingHousesService;

        public PublishingHousesController(IPublishingHousesService publishingHousesService)
        {
            _publishingHousesService = publishingHousesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PublishingHousesResponse>>> GetPublishingHouses()
        {
            var publishingHouses = await _publishingHousesService.GetPublishingHouses();

            var response = publishingHouses.Select(ph => new PublishingHousesResponse(ph.PublishingHouseId, ph.Name, ph.Books));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewPublishingHouse([FromBody] PublishingHousesRequest publishingHousesRequest)
        {
            var publishingHouses = PublishingHouse.Create(
                Guid.NewGuid(),
                publishingHousesRequest.Name,
                publishingHousesRequest.Books);

            var publishingHouseId = await _publishingHousesService.CreatePublishingHouse(publishingHouses);

            return Ok(publishingHouseId);
        }

        [HttpPut("{publishingHouseId:guid}")]
        public async Task<ActionResult<Guid>> UpdatePublishingHouse(Guid publishingHouseId, [FromBody] PublishingHousesRequest publishingHousesRequest)
        {
            var publishingHouse = await _publishingHousesService.UpdatePublishingHouse(
                publishingHouseId,
                publishingHousesRequest.Name,
                publishingHousesRequest.Books);

            return Ok(publishingHouse);
        }

        [HttpDelete("{publishingHouseId:guid}")]
        public async Task<ActionResult<Guid>> DeletePublishingHouse(Guid publishingHouseId)
        {
            return Ok(await _publishingHousesService.DeletePublishing(publishingHouseId));
        }
    }
}