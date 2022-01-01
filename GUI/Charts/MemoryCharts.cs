using System.Collections.Generic;
using ConsoleApp1;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GUI.Charts;

public class MemoryCharts
{
    private readonly Dictionary<string, List<string>> _memoryUsageInfo = MemoryInfo.MemoryUsageInfo();
    
    /// <summary>
    /// Creates Pie Chart For Total Drive Size
    /// </summary>
    /// <returns>SeriesCollection object</returns>
    public SeriesCollection GetTotalMemoryChart()
    {
        var seriesCollection = new SeriesCollection();
        
        foreach (var info in _memoryUsageInfo)
        {
            var title = info.Key;
            var totalSpace = 0.0;

            if (double.TryParse(info.Value[0], out var x))
            {
                totalSpace = x;
            }

            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new ObservableValue(totalSpace)},
                DataLabels = true
            });
        }

        return seriesCollection;
    }
}