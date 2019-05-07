using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class Forecast
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("low")]
        public int Low { get; set; }

        [JsonProperty("high")]
        public int High { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}