namespace Library.Extensions;

public static class TimeOnlyExtension
{
    /// <summary>
    /// Add seconds to TimeOnly object
    /// </summary>
    /// <param name="seconds">seconds value</param>
    /// <returns>Time with seconds</returns>
    public static TimeOnly AddSeconds(this TimeOnly time, int seconds) =>
        time.Add(TimeSpan.FromSeconds(seconds));
    
    /// <summary>
    /// Add milliseconds to TimeOnly object
    /// </summary>
    /// <param name="milliseconds">milliseconds value</param>
    /// <returns>Time with milliseconds</returns>
    public static TimeOnly AddMilliseconds(this TimeOnly time, int milliseconds) =>
        time.Add(TimeSpan.FromMilliseconds(milliseconds));
}