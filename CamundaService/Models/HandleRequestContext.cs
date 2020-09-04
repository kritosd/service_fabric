using CamundaClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CamundaService.Models
{
    public class HandleRequestContext : IHandleRequests
    {
        private readonly HttpContent content;
        private readonly HttpClient _httpClient;
        public readonly string _gatewayUrl;
        private HttpResponseMessage response;
        public HandleRequestContext(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _gatewayUrl = getGatewayUrl();
            response = new HttpResponseMessage();
        }
        public async Task<string> Get(Dictionary<string, object> resultVariables, string postfix)
        {
            response = await _httpClient.GetAsync(_gatewayUrl + postfix); //data?table={table}&primaryKey={primaryKey}");
            string responseContent = "";
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();

                //resultVariables = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

                //await this.CompleteExternalTask();
            }
            return responseContent;
        }
        
        public async Task<Dictionary<string, object>> Post(Dictionary<string, object> resultVariables, string postfix, StringContent content)
        {
            response = await _httpClient.PostAsync(_gatewayUrl + postfix, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                resultVariables = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

                //await this.CompleteExternalTask();
            }
            return resultVariables;
        }

        public async Task<Dictionary<string, object>> Put(Dictionary<string, object> resultVariables, string postfix, StringContent content)
        {
            response = await _httpClient.PutAsync(_gatewayUrl + postfix, content);

            if (response.IsSuccessStatusCode)
            {
                //resultVariables.Add(da.id, da.data);

                var responseContent = await response.Content.ReadAsStringAsync();

                resultVariables = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);


                //await this.CompleteExternalTask();
            }
            return resultVariables;
        }
        /*
        public async Task<HttpResponseMessage> CompleteExternalTask()
        {
            HttpResponseMessage response = await _httpClient.PostAsync(_gatewayUrl + "/Camunda", content);
            return response;
        }*/

        public string getGatewayUrl()
        {
            string Host = Environment.GetEnvironmentVariable("Host");
            string httpGatewayPort = Environment.GetEnvironmentVariable("HttpGatewayPort");

            return $"http://{Host}:{httpGatewayPort}";
        }
    }
}
