using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class DeliveryRequest
    {
        [JsonProperty("sale_id")]
        public int SaleId { get; set; }
    }
}
