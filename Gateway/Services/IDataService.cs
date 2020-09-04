using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.Services
{
    public interface IDataService
    {
        Task<List<List<Data>>> GetDataAsync();

        Task<Dictionary<string, object>> GetDataByKey(string table, string primaryKey);

        Task<HttpResponseMessage> PostData(Data data);
        Task<HttpResponseMessage> PutData(Data data);
    }
}
