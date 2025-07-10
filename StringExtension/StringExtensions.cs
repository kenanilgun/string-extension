using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Dynamic;
// Remove System.Text.Json import for .NET Standard 2.0 compatibility
// using System.Text.Json;

namespace StringExtension
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Checks if the string is null, empty, or consists only of white-space characters.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Converts the string to title case using the current culture.
        /// </summary>
        public static string ToTitleCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Converts the string to an integer. Returns defaultValue if conversion fails.
        /// </summary>
        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out int result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a double. Returns defaultValue if conversion fails.
        /// </summary>
        public static double ToDouble(this string value, double defaultValue = 0)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a decimal. Returns defaultValue if conversion fails.
        /// </summary>
        public static decimal ToDecimal(this string value, decimal defaultValue = 0)
        {
            return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a DateTime. Returns defaultValue if conversion fails.
        /// </summary>
        public static DateTime ToDateTime(this string value, DateTime defaultValue)
        {
            return DateTime.TryParse(value, out DateTime result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a boolean. Returns defaultValue if conversion fails.
        /// </summary>
        public static bool ToBool(this string value, bool defaultValue = false)
        {
            return bool.TryParse(value, out bool result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a Guid. Returns Guid.Empty if conversion fails.
        /// </summary>
        public static Guid ToGuid(this string value)
        {
            return Guid.TryParse(value, out Guid result) ? result : Guid.Empty;
        }

        /// <summary>
        /// Checks if the string can be parsed to DateTime with the given format.
        /// </summary>
        public static bool IsDateTime(this string value, string dateFormat = null)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (dateFormat == null)
                return DateTime.TryParse(value, out _);
            return DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// Converts the string to a 32-bit signed integer. Returns defaultValue if conversion fails.
        /// </summary>
        public static int ToInt32(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out int result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a 64-bit signed integer. Returns defaultValue if conversion fails.
        /// </summary>
        public static long ToInt64(this string value, long defaultValue = 0)
        {
            return long.TryParse(value, out long result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a 16-bit signed integer. Returns defaultValue if conversion fails.
        /// </summary>
        public static short ToInt16(this string value, short defaultValue = 0)
        {
            return short.TryParse(value, out short result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a boolean. Returns defaultValue if conversion fails.
        /// </summary>
        public static bool ToBoolean(this string value, bool defaultValue = false)
        {
            return bool.TryParse(value, out bool result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string to a byte array using UTF8 encoding.
        /// </summary>
        public static byte[] ToBytes(this string value)
        {
            return value == null ? null : Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Checks if the string is a valid integer (Int32).
        /// </summary>
        public static bool IsInteger(this string value)
        {
            return int.TryParse(value, out _);
        }

        /// <summary>
        /// Checks if the string is a valid floating point number.
        /// </summary>
        public static bool IsNumeric(this string value)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Checks if the string contains only Unicode letters.
        /// </summary>
        public static bool IsAlpha(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLetter);
        }

        /// <summary>
        /// Checks if the string contains only Unicode letters and digits.
        /// </summary>
        public static bool IsAlphaNumeric(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Checks if the string is a valid IPv4 address.
        /// </summary>
        public static bool IsValidIPv4(this string value)
        {
            return IPAddress.TryParse(value, out var addr) && addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
        }

        /// <summary>
        /// Checks if the string is a valid email address.
        /// </summary>
        public static bool IsEmailAddress(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            try { var addr = new MailAddress(value); return true; } catch { return false; }
        }

        /// <summary>
        /// Truncates the string to the specified length and appends trailingText if truncated.
        /// </summary>
        public static string Truncate(this string value, int maxLength, string trailingText = "...")
        {
            if (string.IsNullOrEmpty(value) || maxLength < 0) return value;
            return value.Length > maxLength ? value.Substring(0, maxLength) + trailingText : value;
        }

        /// <summary>
        /// Capitalizes the first letter of each word in the string.
        /// </summary>
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Gets the first character of the string, or '\0' if string is null or empty.
        /// </summary>
        public static char FirstCharacter(this string value)
        {
            return !string.IsNullOrEmpty(value) ? value[0] : '\0';
        }

        /// <summary>
        /// Gets the last character of the string, or '\0' if string is null or empty.
        /// </summary>
        public static char LastCharacter(this string value)
        {
            return !string.IsNullOrEmpty(value) ? value[value.Length - 1] : '\0';
        }

        /// <summary>
        /// Replaces all occurrences of the specified characters with an empty string.
        /// </summary>
        public static string Replace(this string value, params char[] chars)
        {
            if (string.IsNullOrEmpty(value) || chars == null || chars.Length == 0) return value;
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
                if (!chars.Contains(c)) sb.Append(c);
            return sb.ToString();
        }

        /// <summary>
        /// Removes all specified characters from the string.
        /// </summary>
        public static string RemoveChars(this string value, params char[] chars)
        {
            return value.Replace(chars);
        }

        /// <summary>
        /// Reverses the string.
        /// </summary>
        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Counts the number of occurrences of a substring in the string.
        /// </summary>
        public static int CountOccurrences(this string value, string substring)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(substring)) return 0;
            int count = 0, index = 0;
            while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                count++;
                index += substring.Length;
            }
            return count;
        }

        /// <summary>
        /// Checks if the string ends with the specified value, ignoring case.
        /// </summary>
        public static bool EndsWithIgnoreCase(this string value, string compare)
        {
            return value?.EndsWith(compare, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        /// <summary>
        /// Checks if the string starts with the specified value, ignoring case.
        /// </summary>
        public static bool StartsWithIgnoreCase(this string value, string compare)
        {
            return value?.StartsWith(compare, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        /// <summary>
        /// Checks if the string does not start with the specified prefix.
        /// </summary>
        public static bool DoesNotStartWith(this string value, string prefix)
        {
            return !(value?.StartsWith(prefix) ?? false);
        }

        /// <summary>
        /// Checks if the string does not end with the specified suffix.
        /// </summary>
        public static bool DoesNotEndWith(this string value, string suffix)
        {
            return !(value?.EndsWith(suffix) ?? false);
        }

        /// <summary>
        /// Appends the suffix if the string does not already end with it.
        /// </summary>
        public static string AppendSuffixIfMissing(this string value, string suffix)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(suffix)) return value;
            return value.EndsWith(suffix) ? value : value + suffix;
        }

        /// <summary>
        /// Appends the prefix if the string does not already start with it.
        /// </summary>
        public static string AppendPrefixIfMissing(this string value, string prefix)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix)) return value;
            return value.StartsWith(prefix) ? value : prefix + value;
        }

        /// <summary>
        /// Returns the left part of the string with the specified length.
        /// </summary>
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0) return string.Empty;
            return value.Length <= length ? value : value.Substring(0, length);
        }

        /// <summary>
        /// Returns the right part of the string with the specified length.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0) return string.Empty;
            return value.Length <= length ? value : value.Substring(value.Length - length);
        }

        /// <summary>
        /// Checks if the string is null.
        /// </summary>
        public static bool IsNull(this string value)
        {
            return value == null;
        }

        /// <summary>
        /// Checks if the string length is at least the specified minimum.
        /// </summary>
        public static bool IsMinLength(this string value, int minLength)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= minLength;
        }

        /// <summary>
        /// Checks if the string length is at most the specified maximum.
        /// </summary>
        public static bool IsMaxLength(this string value, int maxLength)
        {
            return !string.IsNullOrEmpty(value) && value.Length <= maxLength;
        }

        /// <summary>
        /// Checks if the string length is between the specified minimum and maximum.
        /// </summary>
        public static bool IsLength(this string value, int minLength, int maxLength)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= minLength && value.Length <= maxLength;
        }

        /// <summary>
        /// Gets the length of the string, returns 0 if null.
        /// </summary>
        public static int GetLength(this string value)
        {
            return value?.Length ?? 0;
        }

        /// <summary>
        /// Returns an empty string if the value is null.
        /// </summary>
        public static string GetEmptyStringIfNull(this string value)
        {
            return value ?? string.Empty;
        }

        /// <summary>
        /// Returns the default value if the string is null or empty.
        /// </summary>
        public static string GetDefaultIfEmpty(this string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Splits the string by the given separator and converts each element to type T.
        /// </summary>
        public static IEnumerable<T> SplitTo<T>(this string value, char separator)
        {
            if (string.IsNullOrEmpty(value)) yield break;
            foreach (var item in value.Split(separator))
            {
                if (typeof(T) == typeof(string))
                    yield return (T)(object)item;
                else
                {
                    T result = default;
                    try { result = (T)Convert.ChangeType(item, typeof(T)); }
                    catch { continue; }
                    yield return result;
                }
            }
        }

        /// <summary>
        /// Converts the string to the specified Enum type. Returns default(T) if conversion fails.
        /// </summary>
        public static T ToEnum<T>(this string value) where T : struct
        {
            return Enum.TryParse<T>(value, true, out var result) ? result : default;
        }

        /// <summary>
        /// Formats the string with the given arguments.
        /// </summary>
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// Removes the specified prefix from the string if present.
        /// </summary>
        public static string RemovePrefix(this string value, string prefix)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix)) return value;
            return value.StartsWith(prefix) ? value.Substring(prefix.Length) : value;
        }

        /// <summary>
        /// Removes the specified suffix from the string if present.
        /// </summary>
        public static string RemoveSuffix(this string value, string suffix)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(suffix)) return value;
            return value.EndsWith(suffix) ? value.Substring(0, value.Length - suffix.Length) : value;
        }

        /// <summary>
        /// Creates a SHA512 hash of the string and returns as a hex string.
        /// </summary>
        public static string CreateHashSha512(this string value)
        {
            if (value == null) return null;
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        /// <summary>
        /// Creates a SHA256 hash of the string and returns as a hex string.
        /// </summary>
        public static string CreateHashSha256(this string value)
        {
            if (value == null) return null;
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        /// <summary>
        /// Converts a query string to a dictionary of key-value pairs.
        /// </summary>
        public static IDictionary<string, string> QueryStringToDictionary(this string value)
        {
            var dict = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(value)) return dict;
            var query = value.TrimStart('?');
            foreach (var pair in query.Split('&'))
            {
                var kv = pair.Split('=');
                if (kv.Length == 2)
                    dict[Uri.UnescapeDataString(kv[0])] = Uri.UnescapeDataString(kv[1]);
            }
            return dict;
        }

        /// <summary>
        /// Reverses all backslashes and forward slashes in the string.
        /// </summary>
        public static string ReverseSlash(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Replace('/', '\\').Replace('\\', '/');
        }

        /// <summary>
        /// Replaces all line feeds (\n) with the specified replacement.
        /// </summary>
        public static string ReplaceLineFeeds(this string value, string replacement = " ")
        {
            return string.IsNullOrEmpty(value) ? value : value.Replace("\n", replacement);
        }

        /// <summary>
        /// Gets the byte size of the string using the specified encoding (default UTF8).
        /// </summary>
        public static int GetByteSize(this string value, Encoding encoding = null)
        {
            if (value == null) return 0;
            if (encoding == null) encoding = Encoding.UTF8;
            return encoding.GetByteCount(value);
        }

        /// <summary>
        /// Converts the string to an enumerable collection of text elements (grapheme clusters).
        /// </summary>
        public static IEnumerable<string> ToTextElements(this string value)
        {
            if (string.IsNullOrEmpty(value)) yield break;
            var enumerator = StringInfo.GetTextElementEnumerator(value);
            while (enumerator.MoveNext())
                yield return enumerator.GetTextElement();
        }

        /// <summary>
        /// Escapes the string for CSV output by wrapping in quotes and escaping quotes.
        /// </summary>
        public static string ParseStringToCsv(this string value)
        {
            if (value == null) return null;
            if (value.Contains('"')) value = value.Replace("\"", "\"\"");
            return '"' + value + '"';
        }

        /// <summary>
        /// Checks if the string contains the specified substring, ignoring case.
        /// </summary>
        public static bool ContainsIgnoreCase(this string value, string substring)
        {
            if (value == null || substring == null) return false;
            return value.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Checks if the string equals the specified string, ignoring case.
        /// </summary>
        public static bool EqualsIgnoreCase(this string value, string compare)
        {
            return string.Equals(value, compare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if the string has the specified length.
        /// </summary>
        public static bool HasLength(this string value, int length)
        {
            return value != null && value.Length == length;
        }

        /// <summary>
        /// Checks if the string is a valid Guid.
        /// </summary>
        public static bool IsGuid(this string value)
        {
            return Guid.TryParse(value, out _);
        }

        /// <summary>
        /// Checks if all characters in the string are lowercase.
        /// </summary>
        public static bool IsLower(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLower);
        }

        /// <summary>
        /// Checks if all characters in the string are uppercase.
        /// </summary>
        public static bool IsUpper(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsUpper);
        }

        /// <summary>
        /// Checks if all characters in the string are ASCII.
        /// </summary>
        public static bool IsAscii(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(c => c <= 127);
        }

        /// <summary>
        /// Checks if the string is a valid Base64 string.
        /// </summary>
        public static bool IsBase64String(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            value = value.Trim();
            if (value.Length % 4 != 0) return false;
            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the string is a valid hexadecimal string.
        /// </summary>
        public static bool IsHex(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return Regex.IsMatch(value, "\\A\\b[0-9a-fA-F]+\\b\\Z");
        }

        /// <summary>
        /// Checks if the string is a valid URL.
        /// </summary>
        public static bool IsUrl(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return Uri.TryCreate(value, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Checks if the string is a valid phone number (basic international format).
        /// </summary>
        public static bool IsPhoneNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return Regex.IsMatch(value, @"^\+?[1-9]\d{1,14}$");
        }

        /// <summary>
        /// Checks if the string is a palindrome.
        /// </summary>
        public static bool IsPalindrome(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            var cleaned = new string(value.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleaned.SequenceEqual(cleaned.Reverse());
        }

        /// <summary>
        /// Checks if the string is a valid JSON (basic check).
        /// </summary>
        public static bool IsJson(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            value = value.Trim();
            return (value.StartsWith("{") && value.EndsWith("}")) || (value.StartsWith("[") && value.EndsWith("]"));
        }

        // The following methods require System.Text.Json or Newtonsoft.Json, which may not be available in .NET Standard 2.0 by default.
        // Uncomment and use if you add Newtonsoft.Json as a dependency.
        /*
        public static Dictionary<string, object> JsonToDictionary(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
        }

        public static T JsonToObject<T>(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return default;
            return JsonConvert.DeserializeObject<T>(value);
        }
        */

        /// <summary>
        /// Removes diacritics (accent marks) from the string.
        /// </summary>
        public static string RemoveDiacritics(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Removes all special characters from the string, leaving only letters and digits.
        /// </summary>
        public static string RemoveSpecialCharacters(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(char.IsLetterOrDigit).ToArray());
        }

        /// <summary>
        /// Returns only the digits from the string.
        /// </summary>
        public static string OnlyDigits(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Returns only the letters from the string.
        /// </summary>
        public static string OnlyLetters(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(char.IsLetter).ToArray());
        }

        /// <summary>
        /// Returns only the letters and digits from the string.
        /// </summary>
        public static string OnlyLettersOrDigits(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(char.IsLetterOrDigit).ToArray());
        }

        /// <summary>
        /// Collapses multiple whitespace characters into a single space.
        /// </summary>
        public static string CollapseWhitespace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return Regex.Replace(value, "\\s+", " ").Trim();
        }

        /// <summary>
        /// Normalizes all line endings in the string to \n.
        /// </summary>
        public static string NormalizeLineEndings(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Replace("\r\n", "\n").Replace("\r", "\n");
        }

        /// <summary>
        /// Converts the string to a URL-friendly slug.
        /// </summary>
        public static string ToSlug(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var slug = value.RemoveDiacritics().ToLowerInvariant();
            slug = Regex.Replace(slug, "[^a-z0-9]+", "-");
            slug = Regex.Replace(slug, "-+", "-");
            return slug.Trim('-');
        }

        /// <summary>
        /// Repeats the string n times.
        /// </summary>
        public static string Repeat(this string value, int count)
        {
            if (string.IsNullOrEmpty(value) || count <= 0) return string.Empty;
            return string.Concat(Enumerable.Repeat(value, count));
        }

        /// <summary>
        /// Pads the string on the left to the specified total length, safe for null values.
        /// </summary>
        public static string PadLeftSafe(this string value, int totalWidth, char paddingChar = ' ')
        {
            return (value ?? string.Empty).PadLeft(totalWidth, paddingChar);
        }

        /// <summary>
        /// Pads the string on the right to the specified total length, safe for null values.
        /// </summary>
        public static string PadRightSafe(this string value, int totalWidth, char paddingChar = ' ')
        {
            return (value ?? string.Empty).PadRight(totalWidth, paddingChar);
        }

        /// <summary>
        /// Surrounds the string with the specified prefix and suffix.
        /// </summary>
        public static string SurroundWith(this string value, string prefix, string suffix)
        {
            return (prefix ?? string.Empty) + (value ?? string.Empty) + (suffix ?? string.Empty);
        }

        /// <summary>
        /// Removes all whitespace from the string.
        /// </summary>
        public static string RemoveWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        /// <summary>
        /// Removes all numeric characters from the string.
        /// </summary>
        public static string RemoveNumbers(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return new string(value.Where(c => !char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Converts the string to a Base64 encoded string using UTF8 encoding.
        /// </summary>
        public static string ToBase64(this string value)
        {
            if (value == null) return null;
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decodes a Base64 encoded string to its original string using UTF8 encoding.
        /// </summary>
        public static string FromBase64(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            try
            {
                var bytes = Convert.FromBase64String(value);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return value;
            }
        }
    }
} 