using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using CamundaClient.Dto;
using CamundaClient.Worker;
using System.Net.Http;
using Newtonsoft.Json;
using CamundaService.Models;

namespace CamundaService.Worker
{
    [ExternalTaskTopic("EmailService")]
    [ExternalTaskVariableRequirements("email_to", "name_to", "email_from", "name_from", "subject", "htmlContent", "textContent")]
    class EmailAdapter : IExternalTaskAdapter
    {
        private HttpContent content;
        private static HttpClient _httpClient = new HttpClient();
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            // basic auth
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes($"{Environment.GetEnvironmentVariable("ClientId")}:{Environment.GetEnvironmentVariable("ClientSecret")}")));
            
            var myRequest = HandleRequest(externalTask, resultVariables);

            resultVariables = myRequest.GetAwaiter().GetResult();
        }

        public async Task<Dictionary<string, object>> HandleRequest(ExternalTask externalTask, Dictionary<string, object> resultVariables)
        {
            SendEmailDescriptor content = new SendEmailDescriptor()
            {
                to = new MailAddress() { Email = externalTask.Variables["email_to"].Value.ToString(), Name = externalTask.Variables["name_to"].Value.ToString() },
                from = new MailAddress() { Email = externalTask.Variables["email_from"].Value.ToString(), Name = externalTask.Variables["name_from"].Value.ToString() },
                subject = externalTask.Variables["subject"].Value.ToString(),
                htmlContent = externalTask.Variables["htmlContent"].Value.ToString(),
                textContent = externalTask.Variables["textContent"].Value.ToString()
            };

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
            
            HandleRequestContext a = new HandleRequestContext(_httpClient);

            resultVariables = await a.Post(resultVariables, "/email", stringContent);

            return resultVariables;
        }

        public class ExternalTaskDescriptor
        {
            public ExternalTask externalTask { get; set; }
            public Dictionary<string, object> resultVariables { get; set; }
        }


        public class MailAddress
        {
            //
            // Summary:
            //     Initializes a new instance of the StrongGrid.Models.MailAddress class.
            //
            // Parameters:
            //   email:
            //     The email.
            //
            //   name:
            //     The name.
            //public MailAddress(string email, string name);

            //
            // Summary:
            //     Gets or sets the email.
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            public string Email { get; set; }
            //
            // Summary:
            //     Gets or sets the name.
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }
        }

        public class SendEmailDescriptor
        {
            public MailAddress to { get; set; }
            public MailAddress from { get; set; }
            public string subject { get; set; }
            public string htmlContent { get; set; }
            public string textContent { get; set; }
        }
    }
}
