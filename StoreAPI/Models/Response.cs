using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public static Response<T> Success(T data, string message)
        {
            return new Response<T>
            {
                Data = data,
                Message = message,
                State = Dictionary.State.SUCCESS
            };
        }

        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                Data = data,
                Message = "success",
                State = Dictionary.State.SUCCESS
            };
        }

        public static Response<T> Error(string message)
        {
            return new Response<T>
            {
                Message = message,
                State = Dictionary.State.ERROR
            };
        }
    }
}

