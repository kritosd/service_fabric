using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weather;
        private readonly ICamundaService _camunda;

        public WeatherController(IWeatherService weather, ICamundaService camunda)
        {
            _weather = weather;
            _camunda = camunda;
        }
        /*
        [HttpPost]
        public async Task<Dictionary<string, object>> GetCampaigns2([FromBody] ExternalTaskDescriptor d, CancellationToken cancellationToken)
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

                var rsp =  await _weather.GetWeatherAsync(cancellationToken);
                resultVariables.Add("results", rsp);

                // Complete External Task 
                var rsp1 = await _camunda.CompleteExternalTaskById(externalTask.Id, request);


                return resultVariables;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        [HttpGet("{latitude}/{longitude}")]
        public async Task<Forecast> GetWeather(double latitude,double longitude, CancellationToken cancellationToken)
        {
            try
            {
                return await _weather.GetWeatherAsync(latitude, longitude, cancellationToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}