using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Location
    {
        [JsonProperty("woeid")]
        public int Woeid { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("long")]
        public double Long { get; set; }

        [JsonProperty("timezone_id")]
        public string TimezoneId { get; set; }
    }
}