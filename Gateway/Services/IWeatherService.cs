using Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken);
    }
}
