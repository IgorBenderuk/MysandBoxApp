using Microsoft.AspNetCore.Mvc;
using MySandBoxApp.Core.Models;
using TeaMarketPlace.EmailService.Services;

namespace MySandBoxApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly BirthdayNotificationService _birthdayNotificationService;

        public NotificationsController(BirthdayNotificationService birthdayNotificationService)
        {
            _birthdayNotificationService = birthdayNotificationService;
        }

        [HttpPost("send-birthdays")]
        public async Task<IActionResult> SendBirthdayNotifications([FromBody] List<ChildNotificationResponse> children)
        {
            string recipientEmail = "Igor.Benderuk@fivesysdev.com";

            await _birthdayNotificationService.NotifyEmployeesAsync(children, recipientEmail);

            return Ok("Повідомлення успішно відправлено!");
        }
    }
}
