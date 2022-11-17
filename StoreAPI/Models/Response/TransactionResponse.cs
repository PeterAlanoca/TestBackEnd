using Newtonsoft.Json;
using System;

namespace Models.Response
{
    public class TransactionResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("date_time")]
        public string DateTime { get; set; }
    }


}
