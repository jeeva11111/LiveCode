using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveCode.Hubs
{
    public class ConnectedHubs : Hub
    {
        public override async Task OnConnectedAsync()
        {
            ConnectedUsers.UsersList.Add(Context.ConnectionId);
            await Clients.All.SendAsync("UpdateUserList", ConnectedUsers.UsersList);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers.UsersList.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("UpdateUserList", ConnectedUsers.UsersList);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            if (string.IsNullOrEmpty(user))
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
            else
            {
                await Clients.Client(user).SendAsync("ReceiveMessage", user, message);
            }
        }
    }

    public  class ConnectedUsers
    {
        public static List<string> UsersList { get; set; } = new List<string>();
    }
}
