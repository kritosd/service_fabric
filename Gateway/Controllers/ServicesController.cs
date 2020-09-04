using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly ConfigSettings configSettings;
        private readonly StatelessServiceContext serviceContext;
        private readonly HttpClient httpClient;
        private readonly FabricClient fabricClient;


        public ServicesController(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, FabricClient fabricClient)
        {
            this.serviceContext = serviceContext;
            this.configSettings = configSettings;
            this.httpClient = httpClient;
            this.fabricClient = fabricClient;
        }
        // GET api/Services
        [HttpGet]
        public async Task<System.Fabric.Query.ServiceList> GetAsync()
        {

            try
            {
                // foreach service httpGet all infos.

                // get service uri
                string EmailServicesfuri = this.serviceContext.CodePackageActivationContext.ApplicationName + "/" + this.configSettings.EmailServiceName;

                // get list of services
                System.Fabric.Query.ServiceList response = await fabricClient.QueryManager.GetServiceListAsync(new Uri(EmailServicesfuri));
                
                //var rsp = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}