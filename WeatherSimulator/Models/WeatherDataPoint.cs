using System;

public class WeatherDataPoint
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
    public WeatherType Type { get; set; }
}
