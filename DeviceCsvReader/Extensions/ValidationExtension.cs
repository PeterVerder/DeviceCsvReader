using System.Text.RegularExpressions;

namespace DeviceCsvReader.Extensions;
public static class ValidationExtension
{
    public static bool IsAlphaNumeric(string strToCheck)
    {
        Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
        return rg.IsMatch(strToCheck);
    }
}
