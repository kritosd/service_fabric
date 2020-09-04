using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;
using Newtonsoft.Json;
using System.Fabric;
using Microsoft.Extensions.Logging;

namespace Gateway.Services
{
    public class CamundaService : ICamundaService
    {
        private readonly ConfigSettings _configSettings;
        private readonly StatelessServiceContext _serviceContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<CamundaService> _logger;

        public CamundaService(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, ILogger<CamundaService> logger)
        {
            _serviceContext = serviceContext;
            _configSettings = configSettings;
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<HttpResponseMessage> CompleteExternalTaskById(string id, CompleteExternalTask request)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
            
            string CamundaEngineServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.CamundaEngineServiceName;
            
            var rsp = await _httpClient.PostAsync($"http://localhost:{CamundaEngineServicesfuri.Replace("fabric:/App/", "")}/rest/engine/default/external-task/{id}/complete", requestBody);
            return rsp;
        }
    }
}
