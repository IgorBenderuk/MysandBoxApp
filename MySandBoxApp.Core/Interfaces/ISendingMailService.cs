namespace MySandBoxApp.Core.Interfaces
{
    public interface ISendingMailService
    {
        Task SendMessageAsync(Stream messageStream, string receiverId, string fileName);
    }
}
