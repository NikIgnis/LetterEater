using Microsoft.AspNetCore.Mvc;
using OrderService.API.Contracts;
using OrderService.Core.Abstractions;
using OrderService.Core.Models;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _orderItemsService;

        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemsResponse>>> GetOrderItems()
        {
            var orderItems = await _orderItemsService.GetAllOrderItems();

            var response = orderItems.Select(oi => new OrderItemsResponse(oi.OrderItemId, oi.OrderId, oi.BookId, oi.Quantity, oi.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewOrderItem([FromBody] OrderItemsRequest orderItemsRequest)
        {
            var orderItem = OrderItem.Create(
                Guid.NewGuid(),
                orderItemsRequest.OrderId,
                orderItemsRequest.BookId,
                orderItemsRequest.Quantity,
                orderItemsRequest.Price
                );

            var orderItemId = await _orderItemsService.CreateOrderItem(orderItem);

            return Ok(orderItemId);
        }

        [HttpPut("{orderItemId:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrderItem(Guid orderItemId, [FromBody] OrderItemsRequest orderItemsRequest)
        {
            var orderItem = await _orderItemsService.UpdateOrderItem(
                orderItemId,
                orderItemsRequest.OrderId,
                orderItemsRequest.BookId,
                orderItemsRequest.Quantity,
                orderItemsRequest.Price
                );

            return Ok(orderItem);
        }

        [HttpDelete("{orderItemId:guid}")]
        public async Task<ActionResult<Guid>> DeleteOrderItem(Guid orderItemId)
        {
            return Ok(await _orderItemsService.DeleteOrderItem(orderItemId));
        }
    }
}