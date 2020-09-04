using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSController : Controller
    {

        private readonly ISMSService _sms;


        public SMSController(ISMSService sms)
        {
            _sms = sms;
        }


        // GET api/SMS
        [HttpGet]
        public async Task<Message[]> GetMessages()
        {

            try
            {
                return await _sms.GetMessagesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}