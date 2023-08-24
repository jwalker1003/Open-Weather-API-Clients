namespace OpenWeatherCLA.Models
{
    public class WeatherData
    {
        public double CurrentTemp { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public string Descritpion { get; set; }
        public DateTime DateTime { get; set; }

        public WeatherData()
        {
            Descritpion = string.Empty;
        }
    }
}