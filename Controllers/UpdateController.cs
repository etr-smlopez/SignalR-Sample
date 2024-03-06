using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SignalR_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : Controller
    {
        private IHubContext<UpdateHub> _hubContext;

        public UpdateController(IHubContext<UpdateHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> TriggerUpdate()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate");
            return Ok();
        }
    }
}