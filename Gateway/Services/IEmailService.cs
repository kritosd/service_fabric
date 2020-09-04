using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.Services
{
    public interface IEmailService
    {
        Task<HttpResponseMessage> sendEmail(SendEmailDescriptor content);

        Task<Campaign[]> GetCampaignsAsync();

        Task<Campaign> GetCampaignByIdAsync(long id);

        Task<HttpResponseMessage> UpdateCampaignByIdAsync(Campaign campaign);

        Task<HttpResponseMessage> DeleteCampaignByIdAsync(long id);
    }
}
