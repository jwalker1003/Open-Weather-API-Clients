using OpenWeatherCLA.Models;

namespace OpenWeatherCLA
{
    public class DisplayReuslts
    {
        public DisplayReuslts()
        { }

        public static void Display(List<WeatherData> forecast)
        {
            foreach (WeatherData weather in forecast)
            {
                Display(weather);
                Console.WriteLine();
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }
        }

        public static void Display(WeatherData data)
        {
            Console.WriteLine("Desciption: " + data.Descritpion);
            Console.WriteLine("Current Temp: " + data.CurrentTemp);
            Console.WriteLine("Humidity: " + data.Humidity);
            Console.WriteLine("Wind Speed: " + data.WindSpeed);
            Console.WriteLine("Time: " + data.DateTime);
        }
    }
}