using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp1;
using LiveCharts;
using LiveCharts.Defaults;
using GUI.Charts;

namespace GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly MemoryCharts _memoryCharts = new();
    private static readonly MemoryInfo MemoryInfo = new();
    public SeriesCollection MemoryUsageSeriesCollection { get; set; }
    public SeriesCollection MemoryAvailableSeriesCollection { get; set; }
    public Dictionary<string, string> MemoryInfoDictionary { get; set; } = MemoryInfo.GetDriveFormat();

    public MainWindow()
    {
        InitializeComponent();

        InitCharts();

        _ = RunInBackgroundUpdate();
        
        DataContext = this;
    }

    private void InitCharts()
    {
        MemoryUsageSeriesCollection = _memoryCharts.GetTotalMemoryInfo();
        MemoryAvailableSeriesCollection = _memoryCharts.GetAvailableMemoryChart();
    }
    
    /// <summary>
    /// Update available memory info
    /// </summary>
    private void UpdateAvailableMemory()
    {
        var index = 0;
        foreach (var series in MemoryAvailableSeriesCollection)
        {
            foreach (var observable in series.Values.Cast<ObservableValue>())
            {
                var info = MemoryInfo.AvailableMemoryInfo().Values.ToArray();
                observable.Value = info[index];
                index++;
            }
        }
    }

    /// <summary>
    /// Update available memory info every 10 seconds
    /// </summary>
    private async Task RunInBackgroundUpdate()
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));

        while (await periodicTimer.WaitForNextTickAsync())
        {
            UpdateAvailableMemory();
        }
    }
}