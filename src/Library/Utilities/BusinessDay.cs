using HtmlAgilityPack;
using Library.Records;

namespace Library.Utilities;

public static class BusinessDay
{
    private static readonly int _currentYear = DateTime.UtcNow.Year;
    private static readonly string _url = $"https://www.anbima.com.br/feriados/fer_nacionais/{_currentYear}.asp";

    private static string htmlContent = HtmlUtilities.ReturnHtmlContentFromUrl(_url);
    private static IEnumerable<Holiday> holidays = ReturnHolidays(htmlContent);
    
    private static IEnumerable<Holiday> ReturnHolidays(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var list = doc.DocumentNode.SelectSingleNode("//table[@class='interna']")
            .Descendants("tr")
            .Skip(1)
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList());
    
        return list.Select(node => new Holiday(Convert.ToDateTime(node[0]), node[1])).ToList();
    }

    public static DateTime GetNextWeekend(DateTime date)
    {
        while (date.DayOfWeek is not DayOfWeek.Saturday && date.DayOfWeek is not DayOfWeek.Sunday)
            date = date.AddDays(1);

        return date;
    }
    
    public static DateTime GetNextWeekDay(DateTime date)
    {
        while (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            date = date.AddDays(1);

        return date;
    }
    
    public static bool IsBusinessDay(DateTime date) =>
        !IsWeekend(date) && !IsHoliday(date);

    public static bool IsWeekend(DateTime date) =>
        date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    public static bool IsHoliday(DateTime date) =>
        holidays.Any(_ => _.Date.ToString("dd/MM") == date.ToString("dd/MM"));
}