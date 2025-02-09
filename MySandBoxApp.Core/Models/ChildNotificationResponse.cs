namespace MySandBoxApp.Core.Models
{
    public class ChildNotificationResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ParentName { get; set; }
    }
}
