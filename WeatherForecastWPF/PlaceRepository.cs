using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecastWPF
{
    public class PlaceRepository
    {
        public Place GetCityWoeid(string name)
        {
            using(var context = new WeatherContext())
            {
                return context.Places.Include(p => p.Country)
                    .Where(p => p.Name == name)
                    .FirstOrDefault();
            }
        }
        public Place GetCityWoeid(int woeid)
        {
            using (var context = new WeatherContext())
            {
                return context.Places.Include(p => p.Country)
                    .Where(p => p.Woeid == woeid)
                    .FirstOrDefault();
            }
        }
    }
}