using System.Runtime.InteropServices;

namespace ConsoleApp1;

public class OperatingSystemInfo
{
    public static string GetOperatingSystemInfo()
    {
        return RuntimeInformation.OSDescription;
    }
}