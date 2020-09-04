using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoreService.Models;

namespace StoreService.Controllers
{

    [Route("api/[controller]")]
    public class DataController : Controller
    {
        [NonAction]
        public IActionResult Index()
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

            return View(context.GetAllData());
        }

        // GET api/data
        [HttpGet("all")]
        public async Task<List<List<Data>>> Get()
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

            return context.GetAllData();
        }

        // GET api/data/table/sku-001
        [HttpGet("{table}/{primaryKey}")]
        public async Task<string> Get(string table, string primaryKey)
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;
            
            return context.GetDataByKey(table, primaryKey);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] DataDescriptor descriptor)
        {
            try
            {
                DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

                context.PostData(descriptor.Table_Name, descriptor.Data);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            } catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        public async Task Put([FromBody] DataDescriptor descriptor)
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

            context.PutData(descriptor);
        }
    }
        
}
