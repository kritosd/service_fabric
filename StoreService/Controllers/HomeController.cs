using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreService.Models;

namespace StoreService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Tables()
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

            List<tableStructure> Tables = context.getTables();

            return View(Tables);
        }

        [HttpGet]
        public IActionResult Table(string id)
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;

            tableStructure Table = context.getTable(id);

            return View(Table);
        }

        [HttpPost]
        public IActionResult Table(string id, string name, List<field> fields)
        {
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;
            context.UpdateTableName(id, name);
            foreach (var field in fields)
            {
                context.UpdateField(field.id, field.name);
            }

            return Redirect("/home/tables");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string table_name)
        {
            //string table_name = Request.Form["table_name"];
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;
            string table_id = context.InsertIntoTables(table_name);
            return Redirect($"/home/table/createfield/{table_id}");
        }

        [HttpGet]
        public IActionResult CreateField(string table_id)
        {
            return View();
        }

        [HttpPost("/home/table/createfield/{table_id}")]
        public IActionResult CreateField(string table_id, string field_name)
        {
            //string field_name = Request.Form["field_name"];
            DataStoreContext context = HttpContext.RequestServices.GetService(typeof(DataStoreContext)) as DataStoreContext;
            context.InsertIntoFields(table_id, field_name);
            return Redirect($"/home/table/{table_id}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
