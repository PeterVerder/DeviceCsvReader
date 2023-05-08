namespace DeviceCsvReader.Model;
public class Appsettings
{
    public string? FileName { get; set; }
    
    // How to handle the output of the csv file
    // Currently only "Console" is implemented
    public OutputType OutputType { get; set; }
}
