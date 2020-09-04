using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.Services
{
    public interface ISMSService
    {
        Task<Message[]> GetMessagesAsync();
    }
}
