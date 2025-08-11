using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace B39.Common.Extensions;

public static class StringExtension
{
    /// <summary>
    ///     Checks if the string is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty([NotNullWhen(false)]this string? input)
    {
        return string.IsNullOrEmpty(input);
    }

    /// <summary>
    ///     Checks if the string is null, empty, or consists only of whitespace.
    /// </summary>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)]this string? input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

    /// <summary>
    ///     Capitalizes the first letter of the string.
    /// </summary>
    public static string Capitalize(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        return char.ToUpper(input[0]) + input[1..];
    }

    /// <summary>
    ///     Reverses the characters in the string.
    /// </summary>
    public static string Reverse(this string input)
    {
        return new string(input.Reverse().ToArray());
    }

    /// <summary>
    ///     Converts the string to a URL-friendly slug.
    /// </summary>
    public static string ToSlug(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        var noDiacritics = input.RemoveDiacritics();
        var lower = noDiacritics.ToLowerInvariant();
        var normalized = Regex.Replace(lower, @"[^a-z0-9\s-]", ""); // remove invalid chars
        normalized = Regex.Replace(normalized, @"\s+", "-"); // spaces to dash
        normalized = Regex.Replace(normalized, @"-+", "-"); // collapse multiple dashes

        return normalized.Trim('-');
    }

    /// <summary>
    ///     Checks whether the string represents a valid number.
    /// </summary>
    public static bool IsNumeric(this string input)
    {
        return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }

    /// <summary>
    ///     Truncates the string to the specified max length, with optional suffix.
    /// </summary>
    public static string Truncate(this string input, int maxLength, string suffix = "…")
    {
        if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
            return input;

        return input.Substring(0, maxLength) + suffix;
    }

    /// <summary>
    ///     Removes diacritics (accents) from the string.
    /// </summary>
    public static string RemoveDiacritics(this string input)
    {
        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(c);
            if (category != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    /// <summary>
    ///     Removes all whitespace characters from the start and end of the string.
    /// </summary>
    public static string TrimSafe(this string? input)
    {
        return input?.Trim() ?? string.Empty;
    }

    /// <summary>
    ///     Trims only the start (left side) of the string.
    /// </summary>
    public static string TrimStartSafe(this string? input)
    {
        return input?.TrimStart() ?? string.Empty;
    }

    /// <summary>
    ///     Trims only the end (right side) of the string.
    /// </summary>
    public static string TrimEndSafe(this string? input)
    {
        return input?.TrimEnd() ?? string.Empty;
    }

    /// <summary>
    ///     Removes all extra spaces between words (e.g., multiple spaces -> one).
    /// </summary>
    public static string TrimExtraSpaces(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        return Regex.Replace(input.Trim(), @"\s+", " ");
    }

    /// <summary>
    ///     Returns null if the string is null, empty, or whitespace.
    /// </summary>
    public static string? NullIfEmpty(this string? input)
    {
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }
}