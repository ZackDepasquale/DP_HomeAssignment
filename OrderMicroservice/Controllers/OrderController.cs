using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Models;
using OrderMicroservice.Services;
using System;
using System.Threading.Tasks;

namespace OrderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly FirestoreService _firestoreService;

        public OrderController(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            order.Status = "order received not yet dispatched";

            await _firestoreService.AddOrder(order);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _firestoreService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(string orderId)
        {
            var order = await _firestoreService.GetOrder(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
