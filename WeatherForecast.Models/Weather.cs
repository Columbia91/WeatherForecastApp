using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Weather
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current_observation")]
        public CurrentObservation CurrentObservation { get; set; }

        [JsonProperty("forecasts")]
        public List<Forecast> Forecasts { get; set; }
    }
}
