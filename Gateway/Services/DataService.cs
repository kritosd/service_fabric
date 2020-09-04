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
    public class DataService : IDataService
    {
        private readonly ConfigSettings _configSettings;
        private readonly StatelessServiceContext _serviceContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<DataService> _logger;
        public DataService(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, ILogger<DataService> logger)
        {
            _serviceContext = serviceContext;
            _configSettings = configSettings;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<List<Data>>> GetDataAsync()
        {
            string DataServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.DataServiceName;

            string stringContent = await _httpClient.GetStringAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{DataServicesfuri.Replace("fabric:/", "")}/api/data/all");

            return JsonConvert.DeserializeObject<List<List<Data>>>(stringContent);
        }

        public async Task<Dictionary<string, object>> GetDataByKey(string table, string primaryKey)
        {
            string DataServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.DataServiceName;

            string stringContent = await _httpClient.GetStringAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{DataServicesfuri.Replace("fabric:/", "")}/api/data?table={table}&primaryKey={primaryKey}");

            //string a = JsonConvert.DeserializeObject<string>(stringContent);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(stringContent);
        }
        public async Task<HttpResponseMessage> PostData(Data data)
        {
            string DataServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.DataServiceName;

            var dataContent = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{DataServicesfuri.Replace("fabric:/", "")}/api/data", dataContent);

        }
        public async Task<HttpResponseMessage> PutData(Data data)
        {
            string DataServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.DataServiceName;

            var dataContent = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{DataServicesfuri.Replace("fabric:/", "")}/api/data", dataContent);

        }
    }
}