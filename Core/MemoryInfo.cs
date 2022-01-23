
namespace ConsoleApp1;

public class MemoryInfo
{
    private DriveInfo[] _driveInfo = DriveInfo.GetDrives();
    
    public Dictionary<string, double> AvailableMemoryInfo()
    {
        return _driveInfo.ToDictionary<DriveInfo, string, double>(drive => drive.Name,
            drive => Math.Round(drive.AvailableFreeSpace / Math.Pow(1024, 3)));
    }

    public Dictionary<string, double> TotalMemoryInfo()
    {
        return _driveInfo.ToDictionary<DriveInfo?, string, double>(drive => drive.Name,
            drive => Math.Round(drive.TotalSize / Math.Pow(1024, 3)));
    }

    public Dictionary<string, string> GetDriveFormat()
    {
        return _driveInfo.ToDictionary<DriveInfo?, string, string>(drive => drive.Name,
            drive => drive.DriveFormat);
    }
}