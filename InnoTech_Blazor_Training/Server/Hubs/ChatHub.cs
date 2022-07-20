namespace InnoTech_Blazor_Training.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(NotificationMessage message) => await Clients.Others.SendAsync("ReceiveMessage", message);
        public async Task BroadcastMessage(NotificationMessage message) => await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
