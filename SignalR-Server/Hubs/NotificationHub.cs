using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_Server.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message)
        {
            return Clients.Others.SendAsync("Send", message);
        }
    }
}
