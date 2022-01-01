using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ConsoleApp1;
using GUI.Charts;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MemoryCharts _memoryCharts = new MemoryCharts();
        public SeriesCollection SeriesCollection { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            SeriesCollection = _memoryCharts.GetTotalMemoryChart();
            
            DataContext = this;
        }
    }
}