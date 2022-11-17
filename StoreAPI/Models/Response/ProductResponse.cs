using Newtonsoft.Json;
using System;

namespace Models.Response
{
    public class ProductResponse
    {
        [JsonProperty("product")]
        public Product Product { get; set; }
    }
}

