using Newtonsoft.Json;
using OpenWeatherCLA.Models;
using OpenWeatherCLA.Models.CurrentWeather;

namespace OpenWeatherCLA.Convertors
{
    public class OpenWeatherJSONConvertor
    {
        public static CurrentWeatherModel ConvertToCurrentWeatherModel(string json)
        {
            ArgumentException.ThrowIfNullOrEmpty(json);

            try
            {
                return JsonConvert.DeserializeObject<CurrentWeatherModel>(json) ??
                    new CurrentWeatherModel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new CurrentWeatherModel();
        }

        public static ForecastModel ConvertToForecastModel(string json)
        {
            ArgumentException.ThrowIfNullOrEmpty(json);

            try
            {
                return JsonConvert.DeserializeObject<ForecastModel>(json) ??
                    new ForecastModel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new ForecastModel();
        }
    }
}