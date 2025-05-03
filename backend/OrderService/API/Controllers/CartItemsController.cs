using Microsoft.AspNetCore.Mvc;
using OrderService.API.Contracts;
using OrderService.Core.Abstractions;
using OrderService.Core.Models;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItemsService;

        public CartItemsController(ICartItemsService cartItemsService)
        {
            _cartItemsService = cartItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItemsResponse>>> GetAllCartItems()
        {
            var cartItems = await _cartItemsService.GetAllCartItems();

            var respomse = cartItems.Select(ci => new CartItemsResponse(
                ci.CartItemId,
                ci.UserId,
                ci.BookId,
                ci.Quantity,
                ci.Price));

            return Ok(respomse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewCartItem([FromBody] CartItemsRequest cartItemsRequest)
        {
            var cartItem = CartItem.Create(
                Guid.NewGuid(),
                cartItemsRequest.UserId,
                cartItemsRequest.BookId,
                cartItemsRequest.Quantity,
                cartItemsRequest.Price);

            var cartItemId = await _cartItemsService.CreateCartItem(cartItem);

            return Ok(cartItemId);
        }

        [HttpPut("{cartItemId:guid}")]
        public async Task<ActionResult<Guid>> UpdateCartItem(Guid cartItemId, [FromBody] CartItemsRequest cartItemsRequest)
        {
            var cartItem = await _cartItemsService.UpdateCartItem(
                cartItemId,
                cartItemsRequest.UserId,
                cartItemsRequest.BookId,
                cartItemsRequest.Quantity,
                cartItemsRequest.Price);

            return Ok(cartItem);
        }

        [HttpDelete("{cartItemId:guid}")]
        public async Task<ActionResult<Guid>> DeleteAllCartItems(Guid cartItemId)
        {
            return Ok(await _cartItemsService.DeleteAllCartItems(cartItemId));
        }
    }
}
