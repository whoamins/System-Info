using System.Collections.Generic;
using ConsoleApp1;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GUI.Charts;

public class MemoryCharts
{
    private readonly Dictionary<string, List<double>> _memoryUsageInfo = MemoryInfo.MemoryUsageInfo();
    
    /// <summary>
    /// Creates Pie Chart For Total Drive Size
    /// </summary>
    /// <returns>SeriesCollection object</returns>
    public SeriesCollection GetTotalMemoryChart()
    {
        var seriesCollection = new SeriesCollection();
        
        foreach (var (title, value) in _memoryUsageInfo)
        {
            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new (value[0])},
                DataLabels = true
            });
        }

        return seriesCollection;
    }

    public SeriesCollection GetAvailableMemoryChart()
    {
        var seriesCollection = new SeriesCollection();

        foreach (var (title, value) in _memoryUsageInfo)
        {
            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new (value[1])},
                DataLabels = true
            });
        }
        
        return seriesCollection;
    }
}