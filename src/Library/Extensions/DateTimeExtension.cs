namespace Library.Extensions;

public static class DateTimeExtension
{
    /// <summary>Format date to UTC: (yyyy-MM-dd-HH:mm:ss)</summary>
    /// <returns>Return date time formated</returns>
    public static string DateTimeToUtcFormatString(this DateTime dateTime)
        => dateTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
}