using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;
using Newtonsoft.Json;
using System.Fabric;

namespace Gateway.Services
{
    public class EmailService : IEmailService
    {
        private readonly ConfigSettings _configSettings;
        private readonly StatelessServiceContext _serviceContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, ILogger<EmailService> logger)
        {
            _serviceContext = serviceContext;
            _configSettings = configSettings;
            _httpClient = httpClient;
            _logger = logger;
        }
        #region send
        public async Task<HttpResponseMessage> sendEmail(SendEmailDescriptor content)
        {
            string EmailServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.EmailServiceName;

            var emailContent = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{EmailServicesfuri.Replace("fabric:/", "")}/api/emailactivity", emailContent);
            
        }
        #endregion

        #region Campaign
        public async Task<Campaign[]> GetCampaignsAsync()
        {
            string EmailServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.EmailServiceName;

            string stringContent = await _httpClient.GetStringAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{EmailServicesfuri.Replace("fabric:/", "")}/api/campaigns");

            return JsonConvert.DeserializeObject<Campaign[]>(stringContent);
        }

        public async Task<Campaign> GetCampaignByIdAsync(long id)
        {
            string EmailServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.EmailServiceName;

            string stringContent = await _httpClient.GetStringAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{EmailServicesfuri.Replace("fabric:/", "")}/api/campaigns/{id}");

            return JsonConvert.DeserializeObject<Campaign>(stringContent);
        }
        
        public async Task<HttpResponseMessage> UpdateCampaignByIdAsync(Campaign campaign)
        {
            var campaignContent = new StringContent(JsonConvert.SerializeObject(campaign), System.Text.Encoding.UTF8, "application/json");

            string EmailServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.EmailServiceName;
            
            return await _httpClient.PostAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{EmailServicesfuri.Replace("fabric:/", "")}/api/campaigns", campaignContent);
        }

        public async Task<HttpResponseMessage> DeleteCampaignByIdAsync(long id)
        {
            string EmailServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.EmailServiceName;

            return await _httpClient.DeleteAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{EmailServicesfuri.Replace("fabric:/", "")}/api/campaigns/{id}");
        }

        #endregion
    }
}
