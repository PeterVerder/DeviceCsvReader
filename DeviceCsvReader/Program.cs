using DeviceCsvReader.Model;
using DeviceCsvReader.Reader;
using DeviceCsvReader.ResultHandlers;
using DeviceCsvReader.SettingsHandler;

// This application reads information about devices from a csv file and prints only valid devices to the console
namespace DeviceCsvReader;
public class Program
{
    private const string fileName = "Devices.csv";
    private static void Main(string[] args)
    {
        Appsettings settings = AppsettingsHandler.GetAppsettings(); 
        
        DeviceReader deviceReader = new(settings.FileName!);

        List<Devices> devices = deviceReader.GetDevices();

        ResultHandler resultHandler = new();
        resultHandler.Handle(devices, settings.FileName, settings.OutputType);

        _ = Console.ReadLine();
    }
}