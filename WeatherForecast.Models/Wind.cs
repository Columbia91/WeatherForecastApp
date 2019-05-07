using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Wind
    {
        [JsonProperty("chill")]
        public int Chill { get; set; }

        [JsonProperty("direction")]
        public int Direction { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}