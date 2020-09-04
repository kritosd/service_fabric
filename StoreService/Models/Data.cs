using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreService.Models
{
    public class DataListList : List<DataList> { }

    public class DataList : List<Data> { }
    public class Data
    {
        //private DataStoreContext context;

        public string id { get; set; }

        public string data { get; set; }
        
    }

    public class orderData
    {
        //private DataStoreContext context;

        public string id { get; set; }

        public orderJsonData data { get; set; }

    }

    public class DataDescriptor
    {
        public string Table_Name { get; set; }

        public string PrimaryKey { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Data;

    }
    public class Data2
    {
        //public string code { get; set; }

        //public int quantity { get; set; }
        [JsonExtensionData]
        public IDictionary<string, JToken> data;

    }

    public class orderJsonData
    {
        //public string code { get; set; }

        //public int quantity { get; set; }
        [JsonExtensionData]
        public IDictionary<string, JToken> data;

    }

    public class tableStructure
    {
        public string id { get; set; }
        public List<IDictionary<string, string>> rows { get; set; }
        public List<string> fields { get; set; }
    }

    public class row
    {
        public string field { get; set; }
        public string value { get; set; }
    }

    public class tableTable
    {
        public string table_id { get; set; }
        public string table_name { get; set; }
    }

}
