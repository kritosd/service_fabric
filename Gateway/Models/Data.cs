using System.Collections.Generic;

namespace Gateway.Models
{
    public class Data
    {
        public string id { get; set; }

        public orderJsonData data { get; set; }

    }
    
    public class orderData
    {
        //private DataStoreContext context;

        public string id { get; set; }

        public orderJsonData data { get; set; }

    }

    public class orderJsonData
    {
        public string code { get; set; }

        public int quantity { get; set; }

    }
}