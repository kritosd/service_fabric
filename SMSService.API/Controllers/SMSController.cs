using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : Controller
    {
        // Find your Account Sid and Token at twilio.com/console
        // DANGER! This is insecure. See http://twil.io/secure
        const string accountSid = "ACb7b0c1937432a6dd8538e6604f772bf7";
        const string authToken = "940f2f3dc03a70a41a5faedefc9ca20d";

        [HttpPost]
        public async Task<string> Post(string title, long senderId)
        {
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "Hello from the SMSService. Χαιρετε απο το σμσ Σέρβις.",
                from: new Twilio.Types.PhoneNumber("+1 915 800 3415"),
                to: new Twilio.Types.PhoneNumber("+306978534007")
            );

            Console.WriteLine(message.Sid);

            return message.Sid;
        }

        [HttpGet]
        public async Task<Twilio.Base.ResourceSet<MessageResource>> Get()
        {
            TwilioClient.Init(accountSid, authToken);

            var messages = MessageResource.Read();

            return messages;
        }
        
    }
}