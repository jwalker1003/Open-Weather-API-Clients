using OpenWeatherCLA.Models;
using OpenWeatherCLA.Models.CurrentWeather;

namespace OpenWeatherCLA.Convertors
{
    public class WeatherDataConvertor
    {
        public static WeatherData ConvertModel(CurrentWeatherModel currentData)
        {
            try
            {
                var weather = currentData.weather?.FirstOrDefault();

                var wd = new WeatherData
                {
                    CurrentTemp = currentData.main?.temp ?? 0,
                    Humidity = currentData.main?.humidity ?? 0,
                    Descritpion = weather?.description ?? "",
                    WindSpeed = currentData.wind?.speed ?? 0,
                    DateTime = ConvertUnixToDateTime(currentData.dt)
                };
                return wd;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new WeatherData();
        }

        public static List<WeatherData> ConvertModel(ForecastModel forecastData)
        {
            try
            {
                var returnList = new List<WeatherData>();

                foreach (var entry in forecastData.list)
                {
                    var weather = entry.weather.FirstOrDefault();

                    returnList.Add(new WeatherData
                    {
                        CurrentTemp = entry.main?.temp ?? 0,
                        Humidity = entry.main?.humidity ?? 0,
                        Descritpion = weather?.description ?? "",
                        WindSpeed = entry.wind?.speed ?? 0,
                        DateTime = ConvertUnixToDateTime(entry.dt)
                    });
                }

                return returnList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new List<WeatherData>();
        }

        private static DateTime ConvertUnixToDateTime(double unixTime)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(unixTime).ToLocalTime();
        }
    }
}