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
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _email;
        private readonly ICamundaService _camunda;


        public EmailController(IEmailService email, ICamundaService camunda)
        {
            _email = email;
            _camunda = camunda;
        }
        
        // POST api/Email
        [HttpPost]
        public async Task<Dictionary<string, object>> sendEmail([FromBody] ExternalTaskDescriptor d)
        {
            try
            {
                ExternalTask externalTask = d.externalTask;
                Dictionary<string, object> resultVariables = d.resultVariables;

                //externalTask.Variables.Add("sent", true);
                
                CompleteExternalTask request = new CompleteExternalTask() {
                    WorkerId = externalTask.WorkerId,
                    Variables = externalTask.Variables
                };

                // create email descriptor
                SendEmailDescriptor content = new SendEmailDescriptor()
                {
                    to = new MailAddress() { Email = externalTask.Variables["email_to"].Value.ToString(), Name = "kritos_to" },
                    from = new MailAddress() { Email = externalTask.Variables["email_from"].Value.ToString(), Name = "kritos_from" },
                    subject = externalTask.Variables["subject"].Value.ToString(),
                    htmlContent = externalTask.Variables["htmlContent"].Value.ToString(),
                    textContent = externalTask.Variables["textContent"].Value.ToString()
                };

                // send email
                var rsp = await _email.sendEmail(content);

                // Complete External Task 
                var rsp1 = await _camunda.CompleteExternalTaskById(externalTask.Id, request);

                if (rsp.IsSuccessStatusCode)
                {
                    // set variable sent to true
                    resultVariables.Add("sent", true);
                }
                else
                {
                    resultVariables.Add("sent", false);
                }
                

                return resultVariables;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET api/Email
        [HttpGet]
        public async Task<Campaign[]> GetCampaigns()
        {
            try
            {
                //Campaign[] campaignInfo = ;
                //CompleteExternalTask ca = new CompleteExternalTask() { WorkerId = "dwadw" };
                //var resp2 = await _camunda.CompleteExternalTaskById(24124, ca);
                return await _email.GetCampaignsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        // GET api/Email/1234
        [HttpGet("{campaignId}")]
        public async Task<Campaign> GetCampaignsById(long campaignId)
        {
            try
            {
                return await _email.GetCampaignByIdAsync(campaignId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCampaignById([FromBody] Campaign campaign)
        {
            try
            {
                return await _email.UpdateCampaignByIdAsync(campaign);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        [HttpDelete("{campaignId}")]
        public async Task<HttpResponseMessage> DeleteCampaignById(long campaignId)
        {
            try
            {
                return await _email.DeleteCampaignByIdAsync(campaignId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}