using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrongGrid;
using StrongGrid.Models.Search;
using StrongGrid.Models;

namespace EmailService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailActivityController : Controller
    {
        private Client client = new Client(Environment.GetEnvironmentVariable("ApiKey"));

        // Send an email
        // POST api/emailactivity
        [HttpPost]
        public async Task Post([FromBody] SendEmailDescriptor content)
        {
            await client.Mail.SendToSingleRecipientAsync(content.to, content.from, content.subject, content.htmlContent, content.textContent);
        }

        // GET api/email
        [HttpGet]
        public async Task<StrongGrid.Models.EmailMessageActivity[]> Get(IEnumerable<KeyValuePair<SearchLogicalOperator, IEnumerable<ISearchCriteria>>> filterConditions, int limit = 20, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.EmailActivities.SearchAsync(filterConditions);
        }

        // GET api/email/1234
        [HttpGet("{messageId}")]
        public async Task<StrongGrid.Models.EmailMessageSummary> Get(string messageId)
        {
            return await client.EmailActivities.GetMessageSummaryAsync(messageId);
        }


        public class SendEmailDescriptor
        {
            public MailAddress to;
            public MailAddress from;
            public string subject;
            public string htmlContent;
            public string textContent;
        }
    }
}
