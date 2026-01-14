using System;
using System.Collections.Generic;

public class WeatherGenerator
{
    private Random _rnd = new Random();

    public System.Collections.Generic.List<WeatherDataPoint> Generate(int hours, double startTemp = 15)
    {
        var data = new List<WeatherDataPoint>();
        double temp = startTemp;
        double pressure = 1013;
        double humidity = 60;

        for (int i = 0; i < hours; i++)
        {
            // Plynulé zmìny hodnot
            temp += _rnd.NextDouble() * 2 - 1;
            pressure += _rnd.NextDouble() * 1 - 0.5;
            humidity += _rnd.NextDouble() * 3 - 1.5;

            var type = GetWeatherType(temp, humidity);

            data.Add(new WeatherDataPoint
            {
                Time = DateTime.Today.AddHours(i),
                Temperature = temp,
                Pressure = pressure,
                Humidity = humidity,
                Type = type
            });
        }

        return data;
    }

    private WeatherType GetWeatherType(double temp, double humidity)
    {
        if (humidity > 80) return WeatherType.Rainy;
        if (humidity > 60) return WeatherType.Cloudy;
        return WeatherType.Sunny;
    }
}
