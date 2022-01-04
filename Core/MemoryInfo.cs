namespace ConsoleApp1;

public class MemoryInfo
{
    /// <summary>
    /// Gets computer drives info 
    /// </summary>
    /// <returns>Dictionary where key = drive name and value = list of disk characteristics </returns>
    public static Dictionary<string, List<double>> MemoryUsageInfo()
    {
        var drives = DriveInfo.GetDrives();
        var info = new Dictionary<string, List<double>>();

        foreach (var drive in drives)
        {
            var values = new List<double>
            {
                Math.Round(drive.TotalSize / Math.Pow(1024, 3), 2),
                Math.Round(drive.AvailableFreeSpace / Math.Pow(1024, 3), 2)
            };
            
            info.Add(drive.Name, values);
        }

        return info;
    }
}