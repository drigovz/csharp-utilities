namespace Library.Test.Helpers;

internal static class Utils
{
    public static string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(_ => _[Random.Shared.Next(_.Length)]).ToArray());
    }
}