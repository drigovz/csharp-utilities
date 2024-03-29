﻿namespace Library.Extensions;

public static class EnumerableExtension
{
    /// <summary> Verify if collection is null or empty </summary>
    /// <returns> return true if is null or empty </returns>
    public static bool IsNullOrEmpty<T>(this List<T>? source)
        => source is null || !source.Any();
}