using System;
public static class Languages
{
    public const string VN = @"VN";
    public const string EN = @"EN";
}
public static class UtilityHelper
{
    public static bool ToBool(this string value)
    {
        if (value.ToLower() == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        if (!String.IsNullOrEmpty(value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}