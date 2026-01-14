using System;
using System.Collections.ObjectModel;
using System.Linq;

public class SimulationViewModel : ReactiveObject
{
    private readonly WeatherGenerator _generator = new WeatherGenerator();
    private readonly FileService _fileService = new FileService();

    private ObservableCollection<WeatherDataPoint> _data = new ObservableCollection<WeatherDataPoint>();
    public ObservableCollection<WeatherDataPoint> Data
    {
        get => _data;
        set => this.RaiseAndSetIfChanged(ref _data, value);
    }

    private void RaiseAndSetIfChanged(ref ObservableCollection<WeatherDataPoint> data, ObservableCollection<WeatherDataPoint> value)
    {
        throw new NotImplementedException();
    }

    private int _selectedHours = 24;
    public int SelectedHours
    {
        get => _selectedHours;
        set => this.RaiseAndSetIfChanged(ref _selectedHours, value);
    }

    private void RaiseAndSetIfChanged(ref int selectedHours, int value)
    {
        throw new NotImplementedException();
    }

    private double _startTemp = 15;
    public double StartTemp
    {
        get => _startTemp;
        set => this.RaiseAndSetIfChanged(ref _startTemp, value);
    }

    private void RaiseAndSetIfChanged(ref double startTemp, double value)
    {
        throw new NotImplementedException();
    }

    public void Generate()
    {
        Data.Clear();
        foreach (var d in _generator.Generate(SelectedHours, StartTemp))
            Data.Add(d);
    }

    public void SaveJson(string path) => _fileService.SaveJson(path, Data.ToList());

    public void LoadJson(string path)
    {
        Data.Clear();
        foreach (var d in _fileService.LoadJson(path))
            Data.Add(d);
    }
}

