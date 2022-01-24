
namespace ConsoleApp1;

public class OperatingSystemInfo
{
    public static void getOperatingSystemInfo()
    {
        Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.OSDescription);
    }
}