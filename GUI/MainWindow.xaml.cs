﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
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
    private readonly MemoryInfo _memoryInfo = new();
    public SeriesCollection MemoryUsageSeriesCollection { get; set; }
    public SeriesCollection MemoryAvailableSeriesCollection { get; set; }

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

    private void UpdateAvailableMemory()
    {
        var index = 0;
        foreach (var series in MemoryAvailableSeriesCollection)
        {
            foreach (var observable in series.Values.Cast<ObservableValue>())
            {
                var info = _memoryInfo.AvailableMemoryInfo().Values.ToArray();
                observable.Value = info[index];
                index++;
            }
        }
    }

    private async Task RunInBackgroundUpdate()
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));

        while (await periodicTimer.WaitForNextTickAsync())
        {
            UpdateAvailableMemory();
        }
    }
}