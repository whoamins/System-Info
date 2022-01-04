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
        
        foreach (var info in _memoryUsageInfo)
        {
            var title = info.Key;
            
            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new ObservableValue(info.Value[0])},
                DataLabels = true
            });
        }

        return seriesCollection;
    }
}