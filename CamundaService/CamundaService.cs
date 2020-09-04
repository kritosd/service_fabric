using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Data;
using System.Fabric.Description;
using CamundaClient;
using CamundaService.Models;
using System.Net.Http;

namespace CamundaService
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class CamundaService : StatelessService
    {
        public CamundaService(StatelessServiceContext context)
            : base(context)
        {
            //HttpClient client = new HttpClient();
            //HandleRequestContext hrc = new HandleRequestContext(client, context);

            //CamundaEngineClient camunda = new CamundaEngineClient(new System.Uri(hrc._gatewayUrl + "/engine/"), "demo", "demo");
            //camunda.Startup(); // Deploys all models to Camunda and Start all found ExternalTask-Workers
            //Console.ReadLine(); // wait for ANY KEY
            //camunda.Shutdown(); // Stop Task Workers
        }
        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext))
                                            //.AddSingleton<ConfigSettings>(new ConfigSettings(serviceContext)))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
    /*
    public class ConfigSettings
    {
        public ConfigSettings(StatelessServiceContext statelessServiceContext)
        {
            statelessServiceContext.CodePackageActivationContext.ConfigurationPackageModifiedEvent += CodePackageActivationContext_ConfigurationPackageModifiedEvent; ;
            this.UpdateConfiguration(statelessServiceContext.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings);
        }

        private void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> e)
        {
            this.UpdateConfiguration(e.NewPackage.Settings);
        }

        private void UpdateConfiguration(ConfigurationSettings newPackageSettings)
        {
            ConfigurationSection section = newPackageSettings.Sections["ServicesConfig"];
            this.CamundaServiceName = section.Parameters["CamundaServiceName"].Value;
            this.EmailServiceName = section.Parameters["EmailServiceName"].Value;
            this.SMSServiceName = section.Parameters["SMSServiceName"].Value;
            this.WeatherServiceName = section.Parameters["WeatherServiceName"].Value;
            this.CamundaEngineServiceName = section.Parameters["CamundaEngineServiceName"].Value;
            this.DataServiceName = section.Parameters["DataServiceName"].Value;
            this.ReverseProxyPort = int.Parse(section.Parameters["ReverseProxyPort"].Value);
        }

        public String CamundaServiceName { get; set; }

        public String EmailServiceName { get; set; }

        public String SMSServiceName { get; set; }

        public String WeatherServiceName { get; set; }

        public String CamundaEngineServiceName { get; set; }

        public String DataServiceName { get; set; }

        public int ReverseProxyPort { get; set; }
    }
    */
}
