using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Astronomy
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}