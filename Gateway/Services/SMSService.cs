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
    public class SMSService : ISMSService
    {
        private readonly ConfigSettings _configSettings;
        private readonly StatelessServiceContext _serviceContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<SMSService> _logger;

        public SMSService(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, ILogger<SMSService> logger)
        {
            _serviceContext = serviceContext;
            _configSettings = configSettings;
            _httpClient = httpClient;
            _logger = logger;
        }

        #region Message
        public async Task<Message[]> GetMessagesAsync()
        {
            string SMSServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.SMSServiceName;

            string stringContent = await _httpClient.GetStringAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{SMSServicesfuri.Replace("fabric:/", "")}/api/sms");

            return JsonConvert.DeserializeObject<Message[]>(stringContent);
        }

        #endregion
    }
}
