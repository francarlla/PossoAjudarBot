using ExemploWEBApi.Services;
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
        private readonly WebClientService webClientService;
        public MessagesController()
        {
            webClientService = new WebClientService(new Uri("https://msging.net/messages"), "cG9zc29hanVkYXJib3Q6QnpZZUZRclVtSmdSdnVGTDBNbjE=");
        }

        public async Task<IHttpActionResult> Post(JObject message)
        {
           var content = message["content"].Value<string>();
           var from = message["from"].Value<string>();
           var messageContent = "";

            switch (content.Trim())
            {

            }
            var replyMessage = new
            {
                id = Guid.NewGuid(),
                to = from,
                type = "text/plain",
                content = messageContent
            };

            await ReplyMessageAsync(replyMessage);

            return Ok();
        }

        private async Task ReplyMessageAsync(object message)
        {
            var response = await webClientService.SendMessageAsync(message);
        }
    }
}