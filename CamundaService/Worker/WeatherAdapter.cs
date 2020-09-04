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
using Newtonsoft.Json.Linq;
using CamundaService.Models;
using DarkSkyApi.Models;

namespace CamundaService.Worker
{
    [ExternalTaskTopic("WeatherService")]
    [ExternalTaskVariableRequirements("latitude", "longitude")]
    class WeatherAdapter : IExternalTaskAdapter
    {
        private static HttpClient _httpClient = new HttpClient();
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            // basic auth
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes($"{Environment.GetEnvironmentVariable("ClientId")}:{Environment.GetEnvironmentVariable("ClientSecret")}")));

            var myRequest = HandleRequest(externalTask, resultVariables);
            
            Dictionary<string, object> result = myRequest.GetAwaiter().GetResult();
            
            resultVariables = result;
        }

        public async Task<Dictionary<string, object>> HandleRequest(ExternalTask externalTask, Dictionary<string, object> resultVariables)
        {
            double lat = externalTask.Variables.ContainsKey("latitude") ? Double.Parse(externalTask.Variables["latitude"].Value.ToString(), System.Globalization.NumberStyles.Number) : 0;
            double lon = externalTask.Variables.ContainsKey("longitude") ? Double.Parse(externalTask.Variables["longitude"].Value.ToString(), System.Globalization.NumberStyles.Number) : 0;

            HttpResponseMessage response = new HttpResponseMessage();

            HandleRequestContext a = new HandleRequestContext(_httpClient);
            string result = await a.Get(resultVariables, "/weather/" + lat + "/" + lon);

            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(result);
            Dictionary<string, object> rv = new Dictionary<string, object>()
            {
                { "weather_temp", forecast.Currently.Temperature },
                { "weather_summary", forecast.Currently.Summary }
            };
            return rv;
        }

        public class ExternalTaskDescriptor
        {
            public ExternalTask externalTask { get; set; }
            public Dictionary<string, object> resultVariables { get; set; }
        }
    }
}
