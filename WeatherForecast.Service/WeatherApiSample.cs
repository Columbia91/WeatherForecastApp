using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;
using Newtonsoft.Json;

namespace WeatherForecast.Service
{
    public class WeatherApiSample
    {
        private string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        private string cAppID = "sQw1C758";
        private string cConsumerKey = "dj0yJmk9ejVaMFFTc3dwMWFWJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PTFi";
        private string cConsumerSecret = "866272c98f7c9de136722b053786e3067fe4ed2a";
        private string cOAuthVersion = "1.0";
        private string cOAuthSignMethod = "HMAC-SHA1";
        private string cWeatherID = "woeid=";
        private string cUnitID = "u=c";
        private string cFormat = "json";

        public WeatherApiSample(string id)
        {
            cWeatherID += id;
        }
        private string GetTimestamp()
        {
            TimeSpan lTS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(lTS.TotalSeconds).ToString();
        }

        private string GetNonce()
        {
            return Convert.ToBase64String(
             new ASCIIEncoding().GetBytes(
              DateTime.Now.Ticks.ToString()
             )
            );
        }

        private string GetAuth()
        {
            string lNonce = GetNonce();
            string lTimes = GetTimestamp();
            string lCKey = string.Concat(cConsumerSecret, "&");
            string lSign = string.Format(
             "format={0}&" +
             "oauth_consumer_key={1}&" +
             "oauth_nonce={2}&" +
             "oauth_signature_method={3}&" +
             "oauth_timestamp={4}&" +
             "oauth_version={5}&" +
             "{6}&{7}",
             cFormat,
             cConsumerKey,
             lNonce,
             cOAuthSignMethod,
             lTimes,
             cOAuthVersion,
             cUnitID,
             cWeatherID
            );

            lSign = string.Concat(
             "GET&", Uri.EscapeDataString(cURL), "&", Uri.EscapeDataString(lSign)
            );

            using (var lHasher = new HMACSHA1(Encoding.ASCII.GetBytes(lCKey)))
            {
                lSign = Convert.ToBase64String(
                 lHasher.ComputeHash(Encoding.ASCII.GetBytes(lSign))
                );
            }

            return "OAuth " +
                   "oauth_consumer_key=\"" + cConsumerKey + "\", " +
                   "oauth_nonce=\"" + lNonce + "\", " +
                   "oauth_timestamp=\"" + lTimes + "\", " +
                   "oauth_signature_method=\"" + cOAuthSignMethod + "\", " +
                   "oauth_signature=\"" + lSign + "\", " +
                   "oauth_version=\"" + cOAuthVersion + "\"";

        }
        public Weather GetWeatherData()
        {
            string lURL = cURL + "?" + cWeatherID + "&" + cUnitID + "&format=" + cFormat;

            var lClt = new WebClient();

            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("X-Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", GetAuth());
            
            byte[] lDataBuffer = lClt.DownloadData(lURL);

            string json = Encoding.ASCII.GetString(lDataBuffer);
            
            using (StreamWriter writer = new StreamWriter("file.json", false, System.Text.Encoding.Default))
            {
                writer.WriteLine(json);
            }
            
            return JsonConvert.DeserializeObject<Weather>(json);
        }
    }
}
