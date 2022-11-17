using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class BookingRequest
    {
        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
