using CsvHelper;
using DeviceCsvReader.Extensions;
using DeviceCsvReader.Model;
using System.Globalization;

namespace DeviceCsvReader.Reader;
public class DeviceReader
{ 
    private readonly string _fileName;
    
    public DeviceReader(string fileName)
    {
        _fileName = fileName;
    }

    public List<Devices> GetDevices()
    {
        var devices = new List<Devices>();
        using (var reader = new StreamReader(_fileName))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var device = new Devices
                {
                    Name = csv.GetField<string>("Name"),
                    SerialNumber = csv.GetField("SerialNumber")
                };
                if (Valid(device))
                    devices.Add(device);
            }
            return devices;
        }
    }

    private bool Valid(Devices device)
    {
        if(string.IsNullOrEmpty(device.Name))
            return false;
        if (!ValidationExtension.IsAlphaNumeric(device.Name))
            return false;
        if(string.IsNullOrEmpty(device.SerialNumber))
            return false;
        if (!ValidationExtension.IsAlphaNumeric(device.Name))
            return false;
        
        return device.SerialNumber.Length == 10;
    }
}