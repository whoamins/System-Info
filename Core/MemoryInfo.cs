
namespace ConsoleApp1;

public class MemoryInfo
{
    private DriveInfo[] _driveInfo = DriveInfo.GetDrives();
    
    /// <summary>
    /// Returns available free space information
    /// </summary>
    /// <returns>Dictionary with disk name and available free space</returns>
    public Dictionary<string, double> AvailableMemoryInfo()
    {
        return _driveInfo.ToDictionary(drive => drive.Name,
            drive => Math.Round(drive.AvailableFreeSpace / Math.Pow(1024, 3)));
    }

    /// <summary>
    /// Returns available free space information
    /// </summary>
    /// <returns>Dictionary with disk name and total memory space</returns>
    public Dictionary<string, double> TotalMemoryInfo()
    {
        return _driveInfo.ToDictionary<DriveInfo?, string, double>(drive => drive.Name,
            drive => Math.Round(drive.TotalSize / Math.Pow(1024, 3)));
    }

    /// <summary>
    /// Returns drive format
    /// </summary>
    /// <returns>Dictionary with disk name and drive format</returns>
    public Dictionary<string, string> GetDriveFormat()
    {
        return _driveInfo.ToDictionary<DriveInfo?, string, string>(drive => drive.Name,
            drive => drive.DriveFormat);
    }
}