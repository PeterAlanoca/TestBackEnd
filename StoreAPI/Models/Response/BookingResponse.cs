using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response
{
    public class BookingResponse : TransactionResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }


}
