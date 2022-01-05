using System;
using System.Linq;
using System.Windows;
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
    public SeriesCollection MemoryUsageSeriesCollection { get; set; }
    public SeriesCollection MemoryAvailableSeriesCollection { get; set; }
        
    public MainWindow()
    {
        InitializeComponent();

        MemoryUsageSeriesCollection = _memoryCharts.GetTotalMemoryInfo();
        MemoryAvailableSeriesCollection = _memoryCharts.GetAvailableMemoryChart();
            
        DataContext = this;
    }
}