using Microsoft.AspNetCore.SignalR.Client;

namespace InnoTech_Blazor_Training.Client.Pages
{
    public partial class SignalR : IAsyncDisposable
    {
        [Inject]NavigationManager _navigationManager { get; set; }

        private HubConnection? hubConnection;
        private string? subject;
        private string? messageBody;
        private List<NotificationMessage> messages = new();
        protected override async Task OnInitializedAsync()
        {

            hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri("/chathub")).Build();
            hubConnection.On<NotificationMessage>("ReceiveMessage", (message) =>
            {
                messages.Add(message);
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }

        public async Task Send() => await SendNotification("SendMessage");
        public async Task SendKassem() => await SendNotification("BroadcastMessage");
        public async Task SendNotification(string hubSendMethodName)
        {
            List<string> receiverIds = new List<string> { Guid.NewGuid().ToString() };
            NotificationMessage message = new() { Subject = subject, MessageBody = messageBody, SenderId = Guid.NewGuid().ToString(), ReceiverIds = receiverIds, URI = "https://www.google.com" };
            if (hubConnection is not null)
                await hubConnection.SendAsync(hubSendMethodName, message);
        }
        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;
        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
