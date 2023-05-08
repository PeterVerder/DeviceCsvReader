using System.Runtime.Serialization;

namespace DeviceCsvReader.Exceptions;
[Serializable]
internal class AppsettingsException : Exception
{
    public AppsettingsException()
    {
    }

    public AppsettingsException(string? message) : base(message)
    {
    }

    public AppsettingsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected AppsettingsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}