using Newtonsoft.Json;
using StrongGrid;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController
    {
        //var apiKey = "... your api key...";
        private Client client = new Client(Environment.GetEnvironmentVariable("ApiKey"));
        
        [HttpPost]
        public async Task<StrongGrid.Models.Campaign> Post(string title, long senderId)
        {
            return await client.Campaigns.CreateAsync(title, senderId);
        }

        // GET api/campaigns
        [HttpGet]
        public async Task<StrongGrid.Models.Campaign[]> Get()
        {
            return await client.Campaigns.GetAllAsync();
        }

        // GET api/campaigns/1234
        [HttpGet("{campaignId}")]
        public async Task<StrongGrid.Models.Campaign> Get(long campaignId)
        {
            return await client.Campaigns.GetAsync(campaignId);
        }
        
        [HttpPut]
        public async Task<StrongGrid.Models.Campaign> Put([FromBody] StrongGrid.Models.Campaign campaign)
        {
            return await client.Campaigns.UpdateAsync(
                campaign.Id, 
                campaign.Title, 
                campaign.SenderId, 
                campaign.Subject, 
                campaign.HtmlContent, 
                campaign.TextContent, 
                campaign.Lists,
                campaign.Segments,
                campaign.Categories,
                campaign.SuppressionGroupId,
                campaign.CustomUnsubscribeUrl,
                campaign.IpPool,
                campaign.EditorType);
        }

        [HttpDelete("{campaignId}")]
        public async Task Delete(long campaignId)
        {
            await client.Campaigns.DeleteAsync(campaignId);
        }
    }
}
