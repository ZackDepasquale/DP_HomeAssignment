using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Models;
using PaymentMicroservice.Services;
using System.Threading.Tasks;

namespace PaymentMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(Payment payment)
        {
            Payment processedPayment = await _paymentService.ProcessPayment(payment);
            return Ok(processedPayment);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Payment>> GetPayment(string orderId)
        {
            var payment = await _paymentService.GetPaymentByOrderId(orderId);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }
    }
}
