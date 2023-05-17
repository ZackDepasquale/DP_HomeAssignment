using CustomerMicroservice.Models;
using CustomerMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly FirestoreService _firestoreService;

        public UserController()
        {
            _firestoreService = new FirestoreService();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                user.SetPassword(user.Password);
                await _firestoreService.AddUser(user);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var (storedUser, _) = await _firestoreService.GetUserByEmail(user.Email);

            if (storedUser != null && storedUser.CheckPassword(user.Password))
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails([FromQuery] string email)
        {
            var (user, _) = await _firestoreService.GetUserDetails(email);

            if (user != null)
            {
                user.Password = null; // Remove password before returning
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost("notifications")]
        public async Task<IActionResult> AddNotification([FromBody] Dictionary<string, string> body)
        {
            if (body.TryGetValue("userId", out string userId) && body.TryGetValue("message", out string message))
            {
                await _firestoreService.AddNotification(userId, message);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications([FromQuery] string userId)
        {
            List<Notification> notifications = await _firestoreService.GetNotifications(userId);
            return Ok(notifications);
        }

        [HttpGet("getUserId")]
        public async Task<IActionResult> GetUserId([FromQuery] string email)
        {
            var (user, id) = await _firestoreService.GetUserByEmail(email);

            if (user != null)
            {
                return Ok(new { userId = id });
            }

            return NotFound();
        }
    }
}
