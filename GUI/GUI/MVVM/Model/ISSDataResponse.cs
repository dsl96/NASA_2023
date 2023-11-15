using GUI.MVVM.Model;
using Newtonsoft.Json;
using System;

namespace GUI.models
{
    using Newtonsoft.Json;

    public class IssDataResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("velocity")]
        public double Velocity { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("footprint")]
        public double Footprint { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("daynum")]
        public double Daynum { get; set; }

        [JsonProperty("solar_lat")]
        public double SolarLat { get; set; }

        [JsonProperty("solar_lon")]
        public double SolarLon { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("imageData")]
        public byte[] ImageData { get; set; }

        [JsonProperty("DateTime")]
        public DateTime DateTime { get; set; }
    }

}
