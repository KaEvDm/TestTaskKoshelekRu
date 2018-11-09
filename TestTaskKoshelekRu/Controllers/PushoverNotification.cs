using System.Collections.Specialized;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestTaskKoshelekRu.Models;

namespace TestTaskKoshelekRu.Controllers
{
    [Route("api/[controller]")]
    public class PushoverNotification : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]PushoverMessage message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            var parameters = new NameValueCollection {
                { "token", message.AppToken},
                { "user", message.UserKey },
                { "message", message.TextMessage }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }

            return Ok(message);
        }
    }
}
