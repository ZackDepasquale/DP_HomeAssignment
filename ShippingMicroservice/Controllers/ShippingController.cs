using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.Models;
using ShippingMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShippingMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController : ControllerBase
    {
        private readonly FirestoreService _firestoreService;
        private readonly FirestoreDb _firestoreDb;

        public ShippingController(FirestoreService firestoreService, FirestoreDb firestoreDb)
        {
            _firestoreService = firestoreService;
            _firestoreDb = firestoreDb;
        }

        [HttpPost("{orderId}")]
        public async Task<ActionResult<Shipping>> ShipOrder(string orderId)
        {
            var shipping = await _firestoreService.ShipOrder(orderId);
            return Ok(shipping);
        }

        [HttpGet]
        public async Task<ActionResult<List<Shipping>>> GetShippedOrders()
        {
            var shippedOrders = await _firestoreService.GetAllShippedOrders();
            return Ok(shippedOrders);
        }

        [HttpPost("UpdateStatus")]
        public IActionResult UpdateShippingStatus(ShippingStatusUpdate statusUpdate)
        {
            // Get the current date and time
            DateTime shippingDate = DateTime.UtcNow;

            // Call the FirestoreService to update the shipping status and date
            _firestoreService.UpdateShippingStatus(statusUpdate.OrderId, "Shipped", shippingDate);

            return Ok("Shipping status updated successfully");
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetShippingDetails(string orderId)
        {
            ShippingDetails shippingDetails = await _firestoreService.GetShippingDetails(orderId);
            if (shippingDetails == null)
            {
                return NotFound();
            }

            return Ok(shippingDetails);
        }

        [HttpGet("GetDocId/{orderId}")]
        public async Task<ActionResult<string>> GetFirestoreDocId(string orderId)
        {
            string docId = await _firestoreService.GetFirestoreDocId(orderId);
            if (string.IsNullOrEmpty(docId))
            {
                return NotFound();
            }

            return Ok(docId);
        }

    }
}
