using Microsoft.AspNetCore.Mvc;
using OrderService.API.Contracts;
using OrderService.Core.Abstractions;
using OrderService.Core.Models;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdersResponse>>> GetAllOrders()
        {
            var orders = await _ordersService.GetAllOrders();

            var response = orders.Select(o => new OrdersResponse(o.OrderId, o.UserId, o.OrderDate, new List<Guid>(o.OrderItemsId)));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewOrder([FromBody] OrdersRequest ordersRequest)
        {
            var order = Order.Create(
                Guid.NewGuid(),
                ordersRequest.UserId,
                ordersRequest.OrderDate,
                ordersRequest.OrderItemsId);

            var orderId = await _ordersService.CreateOrder(order);

            return Ok(orderId);
        }

        [HttpPut("{orderId:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrder(Guid orderId, [FromBody] OrdersRequest ordersRequest)
        {
            var order = await _ordersService.UpdateOrder(
                orderId,
                ordersRequest.UserId,
                ordersRequest.OrderDate,
                ordersRequest.OrderItemsId);

            return Ok(orderId);
        }

        [HttpDelete("{orderId:guid}")]
        public async Task<ActionResult<Guid>> DeleteAllOrders(Guid orderId)
        {
            return Ok(await _ordersService.DeleteOrder(orderId));
        }
    }
}