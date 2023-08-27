using System.Net;

namespace Library.Utilities;

public static class HtmlUtilities
{
    public static string ReturnHtmlContentFromUrl(string urlAddress)
    {
        try
        {
            return new WebClient().DownloadString(new Uri(urlAddress));
        }
        catch
        {
            return string.Empty;
        }
    }
}