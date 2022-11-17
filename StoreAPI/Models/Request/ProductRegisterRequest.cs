using Newtonsoft.Json;
using System;

namespace Models.Request
{
    public class ProductRegisterRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_cost")]
        public decimal UnitCost { get; set; }
    }
}
