using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecastWPF
{
    public class DataInitializer : CreateDatabaseIfNotExists<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            context.Countries.AddRange(new List<Country>
            {
                new Country
                {
                    Name = "Kazakhstan"
                },
                new Country
                {
                    Name = "USA"
                },
                new Country
                {
                    Name = "Russia"
                }
            });

            context.Places.AddRange(new List<Place>
            {
                new Place
                {
                    Name = "Astana",
                    Type = "city",
                    CountryId = 1,
                    Woeid = 2264962
                },
                new Place
                {
                    Name = "Almaty",
                    Type = "city",
                    CountryId = 1,
                    Woeid = 2255777
                },
                new Place
                {
                    Name = "Zaycan",
                    Type = "town",
                    CountryId = 1,
                    Woeid = 2265046
                },
                new Place
                {
                    Name = "Austin",
                    Type = "city",
                    CountryId = 2,
                    Woeid = 2357536
                },
                new Place
                {
                    Name = "Volgograd",
                    Type = "city",
                    CountryId = 3,
                    Woeid = 2124298
                },
                new Place
                {
                    Name = "Karaganda",
                    Type = "city",
                    CountryId = 1,
                    Woeid = 56121534
                }
            });
        }
    }
}
