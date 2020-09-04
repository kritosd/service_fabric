using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gateway.Models;
using Gateway.Services;
using System.Threading;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CamundaController : Controller
    {
        private readonly ICamundaService _camunda;

        public CamundaController(ICamundaService camunda)
        {
            _camunda = camunda;
        }

        [HttpPost]
        public async Task<Dictionary<string, object>> CompleteExternalTask([FromBody] ExternalTaskDescriptor d, CancellationToken cancellationToken)
        {
            try
            {
                ExternalTask externalTask = d.externalTask;
                Dictionary<string, object> resultVariables = d.resultVariables;

                CompleteExternalTask request = new CompleteExternalTask()
                {
                    WorkerId = externalTask.WorkerId,
                    Variables = externalTask.Variables
                };
                
                // Complete External Task 
                var rsp1 = await _camunda.CompleteExternalTaskById(externalTask.Id, request);
                try
                {
                    rsp1.EnsureSuccessStatusCode();
                    var responseContent = await rsp1.Content.ReadAsStringAsync();

                    //rsp = JsonConvert.DeserializeObject<List<List<Data>>>(responseContent);
                }
                catch(Exception)
                {
                    throw;
                }

                return resultVariables;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}