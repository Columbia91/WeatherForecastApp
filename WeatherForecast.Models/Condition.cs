using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Condition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }
    }
}