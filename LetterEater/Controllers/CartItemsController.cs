using LetterEater.Application.Services;
using LetterEater.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LetterEater.Controllers
{
    [ApiController]
    [Route("api/CartItems/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItemsService;

        public CartItemsController(ICartItemsService cartItemsService)
        {
            _cartItemsService = cartItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItemsResponse>>> GetAllCartItems(CartItemsResponse cartItemsResponse)
        {

        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewCartItem([FromBody] CartItemsRequest cartItemsRequest);
    }
}
