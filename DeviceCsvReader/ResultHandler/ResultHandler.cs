using DeviceCsvReader.Model;

namespace DeviceCsvReader.ResultHandlers;
public class ResultHandler
{
    public ResultHandler()
    {
    }

    public void Handle(List<Devices> devices, string? fileName, OutputType outputType)
    {
        if(outputType.ToString() == OutputType.Console.ToString()) 
        {
            HandleOutputToConsole handleOutputToConsole = new();
            handleOutputToConsole.OutputDevices(devices, fileName!);
        }
        else 
        { 
            throw new NotImplementedException($"The handler with the type {outputType} is not implemented");
        }
    }
}
