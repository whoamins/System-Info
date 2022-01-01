namespace ConsoleApp1;

public class MemoryInfo
{
    public static Dictionary<string, List<string>> MemoryUsageInfo()
    {
        var drives = DriveInfo.GetDrives();
        var info = new Dictionary<string, List<string>>();

        foreach (var drive in drives)
        {
            var values = new List<string>
            {
                $"{drive.TotalSize / Math.Pow(1024, 3):F2}",
                $"{drive.AvailableFreeSpace / Math.Pow(1024, 3):F2}"
            };
            
            info.Add(drive.Name, values);
        }

        return info;
    }

    internal static void ShowMemoryUsage()
    {
        var info = MemoryUsageInfo();

        foreach (var values in info)
        {
            Console.WriteLine(values.Key);

            foreach (var value in values.Value)
            {
                if (double.TryParse(value, out var x))
                    Console.WriteLine($"\t{x}");
            }
        }
    }
}