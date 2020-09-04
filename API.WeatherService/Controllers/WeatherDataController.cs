using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DarkSkyApi;
using DarkSkyApi.Models;
using GoogleMaps.LocationServices;
using Newtonsoft.Json;

namespace API.WeatherService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : Controller
    {
        // GET api/weatherdata
        [HttpGet("{latitude}/{longitude}")]
        public async Task<Forecast> Get(double latitude, double longitude)
        {
            var client = new DarkSkyService(Environment.GetEnvironmentVariable("ApiKey"));
            Forecast result = await client.GetWeatherDataAsync(latitude, longitude);
            JsonConvert.SerializeObject(result);
            return result;
        }
    }
}