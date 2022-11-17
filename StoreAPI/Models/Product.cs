using System;
using Newtonsoft.Json;

namespace Models
{
    public class Product
    {

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_cost")]
        public decimal UnitCost { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}

