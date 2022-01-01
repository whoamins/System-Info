using Microsoft.VisualBasic;

namespace ConsoleApp1;

public class MemoryInfo
{
    /// <summary>
    /// Gets computer drives info 
    /// </summary>
    /// <returns>Dictionary where key = drive name and value = list of disk characteristics </returns>
    public static Dictionary<string, List<string>> MemoryUsageInfo()
    {
        var drives = DriveInfo.GetDrives();
        var info = new Dictionary<string, List<string>>();

        foreach (var drive in drives)
        {
            // TODO: Add to list without ${} construction.
            // I don't know how to add double to list with only 2 numbers after comma, so I use this weird method.
            var values = new List<string>
            {
                $"{drive.TotalSize / Math.Pow(1024, 3):F2}",
                $"{drive.AvailableFreeSpace / Math.Pow(1024, 3):F2}"
            };
            
            info.Add(drive.Name, values);
        }

        return info;
    }
}