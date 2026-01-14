using System.Text.Json;
using System.Globalization;
using System.Collections.Generic;
using System;
using System.IO;

public class FileService
{
    public void SaveJson(string path, List<WeatherDataPoint> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public List<WeatherDataPoint> LoadJson(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<WeatherDataPoint>>(json);
    }

    public void SaveCsv(string path, List<WeatherDataPoint> data)
    {
        using var sw = new StreamWriter(path);
        sw.WriteLine("Time,Temperature,Pressure,Humidity,Type");

        foreach (var d in data)
        {
            sw.WriteLine($"{d.Time},{d.Temperature},{d.Pressure},{d.Humidity},{d.Type}");
        }
    }

    internal void SaveJson(string path, List<WeatherDataPoint> weatherDataPoints) => throw new NotImplementedException();
}
