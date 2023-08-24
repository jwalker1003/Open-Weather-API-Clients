// See https://aka.ms/new-console-template for more information
using OpenWeatherCLA;

var run = true;

while (run)
{
    var imput = Console.ReadLine();

    if (imput?.ToUpper() == "CURRENT")
    {
        var owClient = new OpenWeatherClient();

        var curForecast = await owClient.GetCurrentWeatherAsync("42.16", "-76.89");

        DisplayReuslts.Display(curForecast);
    }

    if (imput?.ToUpper() == "FORECAST")
    {
        var owClient = new OpenWeatherClient();

        var futureForecast = await owClient.GetFiveDayWeatherAsync("42.16", "-76.89");

        DisplayReuslts.Display(futureForecast);
    }

    if (imput?.ToUpper() == "Q")
    {
        run = false;
    }
}