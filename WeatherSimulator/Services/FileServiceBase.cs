using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileServiceBase
{
    public void SaveJson(string path, List<WeatherDataPoint> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    internal void SaveJson(string path, List<WeatherDataPoint> weatherDataPoints)
    {
        throw new NotImplementedException();
    }
}