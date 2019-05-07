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
            WeatherApiSample sample = new WeatherApiSample("2264962");
            var weather = sample.GetWeatherData();

            Dictionary<string, string> types = new Dictionary<string, string>
            {
                {"Partly Cloudy", "partly_cloudy_day@2x.png"},
                { "Mostly Cloudy", "mostly_cloudy_day_night@2x.png"},
                { "Fair", "fair_day@2x.png"},
                { "Sunny", "clear_day@2x.png"}
            };

            foreach (var type in types)
            {
                if (weather.CurrentObservation.Condition.Text == type.Key)
                {
                    ImageSource image = new BitmapImage(new Uri(@"Pictures\" + type.Value, UriKind.RelativeOrAbsolute));
                    ImageFirstDay.Source = image;
                }
            }
        }
    }
}
