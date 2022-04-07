
namespace PLS_Comments_webapi_test.Hub
{
    using Microsoft.AspNetCore.SignalR;
    
    public class CommentsHub : Hub
    {
        public async Task NewMessage(long username, string message) =>
        await Clients.All.SendAsync("MensajeRecibido", username, message);
    }
}
