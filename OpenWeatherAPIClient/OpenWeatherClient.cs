using OpenWeatherCLA.Convertors;
using OpenWeatherCLA.Models;

namespace OpenWeatherCLA
{
    public class OpenWeatherClient
    {
        private readonly string _fiveDayWeatherUi =
            "http://api.openweathermap.org/data/2.5/forecast?units=imperial&lat={0}&lon={1}&appid={2}";

        private readonly string _currentWeahterUri =
            "https://api.openweathermap.org/data/2.5/weather?units=imperial&lat={0}&lon={1}&appid={2}";

        private readonly string _appId = "16496666f6300d826da29d61ab072a26";
        private readonly HttpClient _httpClient = new();

        public OpenWeatherClient()
        { }

        public async Task<WeatherData> GetCurrentWeatherAsync(
            string lat,
            string lon)
        {
            var uri = string.Format(_currentWeahterUri, lat, lon, _appId);
            using HttpResponseMessage response =
                await _httpClient.GetAsync(uri);

            var json = await response.Content.ReadAsStringAsync();
            var current = OpenWeatherJSONConvertor.ConvertToCurrentWeatherModel(json);
            return WeatherDataConvertor.ConvertModel(current);
        }

        public async Task<List<WeatherData>> GetFiveDayWeatherAsync(
            string lat,
            string lon)
        {
            var uri = string.Format(_fiveDayWeatherUi, lat, lon, _appId);
            using HttpResponseMessage response =
                await _httpClient.GetAsync(uri);

            var json = await response.Content.ReadAsStringAsync();

            var forecast = OpenWeatherJSONConvertor.ConvertToForecastModel(json);
            var returnList = new List<WeatherData>();
            return WeatherDataConvertor.ConvertModel(forecast);
        }
    }
}