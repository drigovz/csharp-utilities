namespace Library.Extensions;

public static class StringExtension
{
    public static Stream ToStream(this string value) => ToStream(value, Encoding.UTF8);

    private static Stream ToStream(this string value, Encoding encoding)
        => new MemoryStream(encoding.GetBytes(value ?? string.Empty));
    
    public static bool IsEqual(this string value, string valueCompare)
        => string.Equals(value, valueCompare, StringComparison.OrdinalIgnoreCase);
}