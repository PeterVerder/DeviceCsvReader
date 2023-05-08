using DeviceCsvReader.Exceptions;
using DeviceCsvReader.Model;

namespace DeviceCsvReader.SettingsHandler;
public static class AppsettingsHandler
{
    public static Appsettings GetAppsettings()
    {
        Appsettings settings = new Appsettings();

        settings.FileName = Environment.GetEnvironmentVariable("CsvFileName");
        if (string.IsNullOrWhiteSpace(settings.FileName))
            throw new AppsettingsException("There is no environment variable with the name CsvFileName");
        if (Path.GetExtension(settings.FileName).ToUpper() != ".CSV")
            throw new AppsettingsException("The CsvFileName in environment variables should have the file extension .csv");
        if (!File.Exists(settings.FileName))
            throw new AppsettingsException($"There is no file at {settings.FileName} make sure to include the full path including filename");

        var tmpOutputType = Environment.GetEnvironmentVariable("CsvOutputType");
        if (string.IsNullOrWhiteSpace(tmpOutputType))
            throw new AppsettingsException($"There is no environment variable with the name CsvOutputType. Valid type(s) are: {GetOutputTypes()}");
        settings.OutputType = ValidateAndGetOutputType(tmpOutputType);

        return settings;
    }

    private static OutputType ValidateAndGetOutputType(string tmpOutputType)
    {
        Array names = Enum.GetNames(typeof(OutputType));

        foreach (string name in names)
        {
            if (tmpOutputType.ToUpper() == name.ToUpper())
                return (OutputType)Enum.Parse(typeof(OutputType), name);
        }

        throw new AppsettingsException($"CsvOutputType do not have the correct type. Valid types are: {GetOutputTypes()}");
    }

    private static string GetOutputTypes()
    {
        Array names = Enum.GetNames(typeof(OutputType));

        string result = string.Empty;

        foreach (var name in names) 
        { 
            result += name;
        }

        return result;
    }
}
