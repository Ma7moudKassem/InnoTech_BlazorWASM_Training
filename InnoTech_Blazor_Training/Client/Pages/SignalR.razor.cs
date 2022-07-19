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
            //await InitialHub(hubConnection , "/chathub", "ReciveMessage");
            //await InitialHub(kassemHubConnection, "/kassemhub", "getMessage");

            hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri("/chathub")).Build();
            hubConnection.On<NotificationMessage>("ReceiveMessage", (message) =>
            {
                messages.Add(message);
                StateHasChanged();
            });
            await hubConnection.StartAsync();

            //kassemHubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri("/kassemhub")).Build();
            //kassemHubConnection.On<NotificationMessage>("GetMessage", (message) =>
            //{
            //    messages.Add(message);
            //    StateHasChanged();
            //});
            //await kassemHubConnection.StartAsync();
        }

        //private async Task InitialHub(HubConnection hubConnection, string hubRoute , string hubChannal)
        //{
        //    hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri(hubRoute)).Build();
        //    hubConnection.On<NotificationMessage>(hubChannal, (message) =>
        //    {
        //        messages.Add(message);
        //        StateHasChanged();
        //    });
        //    await hubConnection.StartAsync();
        //}

        //public async Task Send()=> await SendNotification(hubConnection, "SendMessage");
        //public async Task SendKassem() => await SendNotification(kassemHubConnection, "BroadcastMessage");

        //public async Task SendNotification(HubConnection hubConnection , string hubSendMessage)
        //{
        //    List<string> receiverIds = new List<string> { Guid.NewGuid().ToString() };
        //    NotificationMessage message = new() { Subject = subject, MessageBody = messageBody, SenderId = Guid.NewGuid().ToString() , ReceiverIds = receiverIds , URI = "https://www.google.com" };
        //    if (hubConnection is not null)
        //        await hubConnection.SendAsync(hubSendMessage, message); 
        //        //await kassemHubConnection.SendAsync("BroadcastMessage", message); 
        //}        
        
        //public async Task Send()
        //{
        //    List<string> receiverIds = new List<string> { Guid.NewGuid().ToString() };
        //    NotificationMessage message = new() { Subject = subject, MessageBody = messageBody, SenderId = Guid.NewGuid().ToString() , ReceiverIds = receiverIds , URI = "https://www.google.com" };
        //    if (hubConnection is not null)
        //        await hubConnection.SendAsync("SendMessage", message);

        //}        
        //public async Task SendKassem()
        //{
        //    List<string> receiverIds = new List<string> { Guid.NewGuid().ToString() };
        //    NotificationMessage message = new() { Subject = subject, MessageBody = messageBody, SenderId = Guid.NewGuid().ToString() , ReceiverIds = receiverIds , URI = "https://www.google.com" };
        //    if (kassemHubConnection is not null)
        //        await kassemHubConnection.SendAsync("BroadcastMessage", message);
        //}

        public async Task Send() => await SendNotification("SendMessage");
        public async Task SendKassem() => await SendNotification("BroadcastMessage");
        public async Task SendNotification(string hubSendMethodName)
        {
            List<string> receiverIds = new List<string> { Guid.NewGuid().ToString() };
            NotificationMessage message = new() { Subject = subject, MessageBody = messageBody, SenderId = Guid.NewGuid().ToString(), ReceiverIds = receiverIds, URI = "https://www.google.com" };
            if (hubConnection is not null)
                await hubConnection.SendAsync(hubSendMethodName, message);
            //await kassemHubConnection.SendAsync("BroadcastMessage", message); 
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
