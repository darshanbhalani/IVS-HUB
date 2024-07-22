using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace IVS_HUB.Hubs
{
    public class LiveElectionHub : Hub
    {
        private async Task BroadcastData()
        {
            List<string> data = ["Hello","Baccho"];
            await Clients.All.SendAsync("ABCD", data);
        }
    }
}
