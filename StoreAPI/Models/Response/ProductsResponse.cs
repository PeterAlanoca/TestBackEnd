using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.Response
{
    public class ProductsResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}

