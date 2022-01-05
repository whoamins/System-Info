using ConsoleApp1;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GUI.Charts;

public class MemoryCharts
{
    private MemoryInfo _memoryInfo = new MemoryInfo();

    /// <summary>
    /// Creates Pie Chart For Available Drive Size
    /// </summary>
    /// <returns>SeriesCollection object</returns>
    public SeriesCollection GetAvailableMemoryChart()
    {
        var seriesCollection = new SeriesCollection();

        foreach (var (title, value) in _memoryInfo.AvailableMemoryInfo())
        {
            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new (value)},
                DataLabels = true
            });
        }

        return seriesCollection;
    }
    
    /// <summary>
    /// Creates Pie Chart For Total Drive Size
    /// </summary>
    /// <returns>SeriesCollection object</returns>
    public SeriesCollection GetTotalMemoryInfo()
    {
        var seriesCollection = new SeriesCollection();

        foreach (var (title, value) in _memoryInfo.TotalMemoryInfo())
        {
            seriesCollection.Add(new PieSeries
            {
                Title = title,
                Values = new ChartValues<ObservableValue> {new (value)},
                DataLabels = true
            });
        }

        return seriesCollection;
    }
}