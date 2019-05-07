using Newtonsoft.Json;
using System;

namespace WeatherForecast.Models
{
    public class CurrentObservation
    {
        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("atmosphere")]
        public Atmosphere Atmosphere { get; set; }

        [JsonProperty("astronomy")]
        public Astronomy Astronomy { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("pubDate")]
        public int PubDate { get; set; }
    }
}