using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Atmosphere
    {
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("rising")]
        public int Rising { get; set; }
    }
}