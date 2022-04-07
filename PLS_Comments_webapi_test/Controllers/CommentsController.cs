using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PLS_Comments_webapi_test.Hub;
using PLS_Comments_webapi_test.Models;

namespace PLS_Comments_webapi_test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private IHubContext<CommentsHub> _hub;

        public CommentsController(IHubContext<CommentsHub> hub)
        {
            _hub = hub;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _hub.Clients.All.SendAsync(id, "Connected");
            return Ok(new { Message = "Request Completed" });
        }

        [HttpPost("{id}")]
        public IActionResult PostComments([FromBody]Comments comments, [FromRoute] string id)
        {
            _hub.Clients.All.SendAsync(id, comments);

            return Ok();
        }
    }


}
