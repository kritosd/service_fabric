using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
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
            ConfigurationSection section = newPackageSettings.Sections["GatewayConfig"];
            this.EmailServiceName = section.Parameters["EmailServiceName"].Value;
            this.SMSServiceName = section.Parameters["SMSServiceName"].Value;
            this.WeatherServiceName = section.Parameters["WeatherServiceName"].Value;
            this.CamundaEngineServiceName = section.Parameters["CamundaEngineServiceName"].Value;
            this.DataServiceName = section.Parameters["DataServiceName"].Value;
            this.ReverseProxyPort = int.Parse(section.Parameters["ReverseProxyPort"].Value);
        }


        public String EmailServiceName { get; set; }

        public String SMSServiceName { get; set; }

        public String WeatherServiceName { get; set; }

        public String CamundaEngineServiceName { get; set; }

        public String DataServiceName { get; set; }

        public int ReverseProxyPort { get; set; }
    }
}
