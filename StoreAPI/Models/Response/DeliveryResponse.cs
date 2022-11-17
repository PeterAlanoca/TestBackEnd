using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response
{
    public class DeliveryResponse 
    { 
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("iva")]
        public decimal Iva { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("date_time")]
        public string DateTime { get; set; }
    }
}
