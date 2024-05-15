namespace Library.Extensions;

public static class DateOnlyExtension
{
    /// <summary>
    /// Calculate difference days between two dates
    /// </summary>
    /// <param name="dateOnly">Greater date</param>
    /// <param name="dateSubtract">Less date</param>
    /// <returns>int with number of days</returns>
    public static int DaysDifference(this DateOnly dateOnly, DateOnly dateSubtract) =>
        dateOnly.DayNumber - dateSubtract.DayNumber;
    
    /// <summary>
    /// Calculate aproximated years with difference of days with parameter
    /// </summary>
    /// <param name="dateOnly">Number os days between two dates</param>
    /// <returns>int with numbers of years</returns>
    public static int YearsDifference(this DateOnly dateOnly, int differeceDays) =>
        differeceDays / 365;
    
    /// <summary>
    /// Calculate difference between two dates
    /// </summary>
    /// <param name="dateOnly">Greater date</param>
    /// <param name="dateSubtract">Less date</param>
    /// <returns>int with numbers of years</returns>
    public static int CalculateDiferrence(this DateOnly dateOnly, DateOnly dateSubtract) => 
        dateOnly.YearsDifference(dateOnly.DaysDifference(dateSubtract));
}
