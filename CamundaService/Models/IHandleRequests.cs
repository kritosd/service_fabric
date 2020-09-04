using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CamundaService.Models;

namespace CamundaService.Models
{
    public interface IHandleRequests
    {
        Task<string> Get(Dictionary<string, object> resultVariables, string postfix);
        Task<Dictionary<string, object>> Post(Dictionary<string, object> resultVariables, string postfix, StringContent content);
        Task<Dictionary<string, object>> Put(Dictionary<string, object> resultVariables, string postfix, StringContent content);
    }
    
}
