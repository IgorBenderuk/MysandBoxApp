using MySandBoxApp.Core.Models;

namespace MySandBoxApp.Core.Interfaces
{
    public interface IRazorViewRenderer
    {
        Task<Stream> RenderViewToStringAsync(List<ChildNotificationResponse> childrenModel);
    }
}
