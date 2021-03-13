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
using CamundaService.Models;
using Newtonsoft.Json.Linq;
using StoreService.Models;

namespace CamundaService.Worker
{
    [ExternalTaskTopic("DataService",1,30)]
    [ExternalTaskVariableRequirements("Action", "Table", "PrimaryKey", "Data")]
    class DataAdapter : IExternalTaskAdapter
    {
        private HttpContent content;
        private static HttpClient _httpClient = new HttpClient();
        private static string Postfix = "/data";
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
            string action = externalTask.Variables.ContainsKey("Action") ? externalTask.Variables["Action"].Value.ToString() : null;
            string table = externalTask.Variables.ContainsKey("Table") ? externalTask.Variables["Table"].Value.ToString() : null;
            string primaryKey = externalTask.Variables.ContainsKey("PrimaryKey") ? externalTask.Variables["PrimaryKey"].Value.ToString() : null;
            string data = externalTask.Variables.ContainsKey("Data") ? externalTask.Variables["Data"].Value.ToString() : null;

            DataDescriptor descriptor = new DataDescriptor()
            {
                Table_Name = table,
                PrimaryKey = primaryKey,
                Data = data != null ? JsonConvert.DeserializeObject<IDictionary<string, JToken>>(data) : null
            };

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(descriptor), System.Text.Encoding.UTF8, "application/json");


            HttpResponseMessage response = new HttpResponseMessage();

            HandleRequestContext a = new HandleRequestContext(_httpClient);

            switch (action)
            {
                case "GET":
                    string result = await a.Get(resultVariables, Postfix + "/" + descriptor.Table_Name + "/" + descriptor.PrimaryKey);
                
                    resultVariables = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    break;
                case "POST":
                    resultVariables = await a.Post(resultVariables, Postfix, stringContent);
                    break;
                case "PUT":
                    resultVariables = await a.Put(resultVariables, Postfix, stringContent);
                    break;
            }

            return resultVariables;
        }
    }
}
