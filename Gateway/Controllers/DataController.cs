using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Cors;

namespace Gateway.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IDataService _data;
        private readonly ICamundaService _camunda;

        public DataController(IDataService data, ICamundaService camunda)
        {
            _data = data;
            _camunda = camunda;
        }

        [HttpGet]
        public async Task<List<List<Data>>> GetData()
        {
            try
            {
                //Campaign[] campaignInfo = ;
                //CompleteExternalTask ca = new CompleteExternalTask() { WorkerId = "dwadw" };
                //var resp2 = await _camunda.CompleteExternalTaskById(24124, ca);
                return await _data.GetDataAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{table}/{primaryKey}")]
        public async Task<Dictionary<string, object>> GetDataByKey(string table, string primaryKey)
        {
            try
            {

                return await _data.GetDataByKey(table, primaryKey);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostData([FromBody] Data Data)
        {
            try
            {
                return await _data.PostData(Data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> PutData([FromBody] Data Data)
        {
            try
            {
                return await _data.PutData(Data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}