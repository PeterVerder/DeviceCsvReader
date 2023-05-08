using CsvHelper.Configuration.Attributes;

namespace DeviceCsvReader.Model;
[Delimiter(",")]
public class Devices
{
    public string? Name { get; set; }      
    public string? SerialNumber { get; set; }
}
