using IVS_HUB.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace IVS_HUB.Controllers.StateElections
{
    [Route("IVS-Hub")]
    [ApiController]
    public class LiveElectionController : ControllerBase
    {
        private readonly IHubContext<LiveElectionHub> _hubContext;
        public LiveElectionController(IHubContext<LiveElectionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult>  BroadCastData()
        {
            LiveElectionHub hub = new LiveElectionHub();
            //await hub.BroadcastData();
            List<string> data = ["Hello", "Baccho"];
            await _hubContext.Clients.All.SendAsync("ABCD", data);
            return Ok();
        }
    }
}
