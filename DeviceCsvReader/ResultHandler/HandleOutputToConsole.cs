using DeviceCsvReader.Model;

namespace DeviceCsvReader.ResultHandlers;
public class HandleOutputToConsole
{
    public void OutputDevices(List<Devices> devices, string fileName)
    {
        if (!devices.Any()) 
        {
            Console.WriteLine($"No valid devices found in {fileName}");
        }
        else 
        {
            Console.WriteLine($"Following devices where found in {fileName}");
        }

        foreach (Devices device in devices)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {device.Name}");
            Console.WriteLine($"Serial Number: {device.SerialNumber}");
            Console.WriteLine();
        }
    }
}
