using GUI.MVVM.Model;
using Newtonsoft.Json;
using System;

namespace GUI.models
{
    public class IssLocationResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("dateTime")]
        public DateTime dateTime { get; set; }

        [JsonProperty("iss_position")]
        public IssPosition iss_position { get; set; }

        [JsonProperty("imageData")]
        public byte[] imageData { get; set; }  
    }   
}
