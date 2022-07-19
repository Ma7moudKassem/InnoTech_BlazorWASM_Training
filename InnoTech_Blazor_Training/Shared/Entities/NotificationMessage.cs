namespace InnoTech_Blazor_Training.Shared.Entities
{
    public class NotificationMessage
    {
        public string? SenderId { get; set; }
        public string? Subject { get; set; }
        public string? MessageBody { get; set; }
        public string? URI { get; set; }
        public List<string>? ReceiverIds { get; set; }
    }
}
