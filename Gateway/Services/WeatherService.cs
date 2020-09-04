using Gateway.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Fabric;
using Gateway.Models;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ConfigSettings _configSettings;
        private readonly StatelessServiceContext _serviceContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailService> _logger;

        public WeatherService(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, ILogger<EmailService> logger)
        {
            _serviceContext = serviceContext;
            _configSettings = configSettings;
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<Forecast> GetWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken)
        {
            string WeatherServicesfuri = _serviceContext.CodePackageActivationContext.ApplicationName + "/" + _configSettings.WeatherServiceName;

            using (var response = await _httpClient.GetAsync($"http://localhost:{_configSettings.ReverseProxyPort}/{WeatherServicesfuri.Replace("fabric:/", "")}/api/weatherdata/{latitude}/{longitude}", cancellationToken))
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == false)
                {
                    throw new ApiException
                    {
                        StatusCode = (int)response.StatusCode,
                        Content = content
                    };
                }

                return JsonConvert.DeserializeObject<Forecast>(content);
            }
        }

        public class ApiException : Exception
        {
            public int StatusCode { get; set; }

            public string Content { get; set; }
        }
    }
}
