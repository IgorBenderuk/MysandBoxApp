using MySandBoxApp.Core.Interfaces;
using MySandBoxApp.Core.Models;

namespace TeaMarketPlace.EmailService.Services
{
    public class BirthdayNotificationService
    {
        private readonly IRazorViewRenderer _razorViewRenderer;
        private readonly ISendingMailService _sendingMailService;

        public BirthdayNotificationService(
            IRazorViewRenderer razorViewRenderer,
            ISendingMailService sendingMailService)
        {
            _razorViewRenderer = razorViewRenderer;
            _sendingMailService = sendingMailService;
        }

        public async Task NotifyEmployeesAsync(List<ChildNotificationResponse> children, string recipientEmail)
        {
            Stream htmlContent = await _razorViewRenderer.RenderViewToStringAsync(
                 children);

            await _sendingMailService.SendMessageAsync(htmlContent, recipientEmail, "notification");

        }
    }
}