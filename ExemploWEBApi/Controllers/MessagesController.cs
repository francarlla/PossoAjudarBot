using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ExemploWEBApi.Controllers
{
    public class MessagesController : ApiController
    {
        public MessagesController()
        {
        }

        public async Task<IHttpActionResult> Post(JObject jsonObject)
        {
           // var content = message["content"].Value<string>();
           // var from = message["from"].Value<string>();
           // var messageContent = "";

            //switch (content.Trim())
            //{

            //}

           // var replyMessage = "{'id': '"+ Guid.NewGuid() + "', 'to': '" + from + "', 'type': 'text/plain', 'content': '" + messageContent + "'}";
          //  await ReplyMessageAsync(replyMessage);
            return Ok();
        }
    }
}