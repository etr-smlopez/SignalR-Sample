using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class UpdateHub : Hub
{
    public async Task SendUpdate(string message)
    {
        await Clients.All.SendAsync("ReceiveUpdate", message);
    }
}

//using Microsoft.AspNetCore.SignalR;
//using System.Threading.Tasks;

//public class UpdateHub : Hub
//{
//    public async Task SendUpdate(string updateMessage)
//    {
//        // Broadcast the update to all connected clients
//        await Clients.All.SendAsync("ReceiveUpdate", updateMessage);
//    }
//}

//using Microsoft.AspNetCore.SignalR;
//using System.Threading.Tasks;

//public class UpdateHub : Hub
//{
//    public async Task NotifyDatabaseChange(string changeType)
//    {
//        // Broadcast the database change to connected clients
//        await Clients.All.SendAsync("ReceiveDatabaseChange", changeType);
//    }
//}
