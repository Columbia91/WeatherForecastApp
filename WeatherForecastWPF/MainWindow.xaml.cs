using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherForecast.Models;
using WeatherForecast.Service;

namespace WeatherForecastWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int currentLocationWoeid = 2264962; // Astana
            PlaceRepository placeRepository = new PlaceRepository();
            var place = placeRepository.GetCityWoeid(currentLocationWoeid);
            if (place != null)
                ShowWeather(place);
        }
        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            PlaceRepository placeRepository = new PlaceRepository();
            var place = placeRepository.GetCityWoeid(TextBoxPlace.Text);
            if (place != null)
                ShowWeather(place);
            else
            {
                MessageBox.Show("Unfortunately this city is unknown to us", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxPlace.Clear();
            }
        }
        private void ShowWeather(Place place)
        {
            WeatherApiSample sample = new WeatherApiSample(place.Woeid.ToString());
            var weather = sample.GetWeatherData();

            Dictionary<string, string> types = new Dictionary<string, string>
            {
                { "Blustery", "windy_day_night@2x.png" },
                { "Cloudy", "cloudy_day_night@2x.png" },
                { "Partly Cloudy", "partly_cloudy_day@2x.png" },
                { "Mostly Sunny", "fair_day@2x.png" },
                { "Mostly Cloudy", "mostly_cloudy_day_night@2x.png" },
                { "Fair", "fair_day@2x.png" },
                { "Sunny", "clear_day@2x.png" },
                { "Showers", "rain_day_night@2x.png" },
                { "Scattered Thunderstorms", "scattered_showers_day_night@2x.png" },
                { "Mixed Rain and Snow", "snow_rain_mix_day_night@2x.png" }
            };

            int daysInWeek = 7;
            TextBlock[] textBlocks = new TextBlock[]
            {
                TextBlockFirstDay, TextBlockSecondDay, TextBlockThirdDay,
                TextBlockFourthDay, TextBlockFifthDay, TextBlockSixthDay, TextBlockSeventhDay
            };

            Image[] images = new Image[]
            {
                ImageFirstDay, ImageSecondDay, ImageThirdDay,
                ImageFourthDay, ImageFifthDay, ImageSixthDay, ImageSeventhDay
            };

            TextBox[] textBoxes = new TextBox[]
            {
                TextBoxFirstDay, TextBoxSecondDay, TextBoxThirdDay,
                TextBoxFourthDay, TextBoxFifthDay, TextBoxSixthDay, TextBoxSeventhDay
            };

            LabelPlaceName.Content = place.Name;
            LabelCountryName.Content = place.Country.Name;
            for (int i = 0; i < daysInWeek; i++)
            {
                if (i == 0)
                {
                    foreach (var type in types)
                    {
                        if (weather.CurrentObservation.Condition.Text == type.Key)
                        {
                            ImageSource image = new BitmapImage(new Uri(@"Pictures\" + type.Value, UriKind.RelativeOrAbsolute));
                            images[i].Source = image;
                            textBoxes[i].Text = weather.CurrentObservation.Condition.Text;
                            textBlocks[i].Text = $" TODAY {DateTime.Now.ToShortDateString()}\n\n" +
                                $" Temp now: {weather.CurrentObservation.Condition.Temperature}°C\n" + // ALT + 0176
                                $" Humidity: {weather.CurrentObservation.Atmosphere.Humidity}%\n" +
                                $" Wind: {weather.CurrentObservation.Wind.Speed} м/c\n\n" +
                                $" High: {weather.Forecasts[i].High}°C\n" +
                                $" Low: {weather.Forecasts[i].Low}°C";
                        }
                    }
                }
                else
                {
                    foreach (var type in types)
                    {
                        if (weather.Forecasts[i].Text == type.Key)
                        {
                            ImageSource image = new BitmapImage(new Uri(@"Pictures\" + type.Value, UriKind.RelativeOrAbsolute));
                            images[i].Source = image;
                            textBoxes[i].Text = weather.Forecasts[i].Text;
                            textBlocks[i].Text = $" {weather.Forecasts[i].Day} {DateTime.Now.AddDays(i).ToShortDateString()}\n\n" +
                                $" High Temp: {weather.Forecasts[i].High}°C\n" +
                                $" Low Temp: {weather.Forecasts[i].Low}°C";
                        }
                    }
                }
            }
        }
    }
}
