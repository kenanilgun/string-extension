# StringExtension

A comprehensive C# extension library providing a wide range of string manipulation and validation methods. Designed for .NET Standard 2.0 compatibility, this library helps you work with strings more efficiently and expressively in your C# projects.

## Features
- Null/empty/whitespace checks
- Type conversions (int, double, decimal, DateTime, Guid, etc.)
- String formatting and casing (title case, capitalize, etc.)
- Validation (email, IP, URL, phone, Base64, hex, Guid, etc.)
- Trimming, padding, and substring utilities
- Hashing (SHA256, SHA512)
- Slug generation
- Palindrome, JSON, and numeric checks
- Diacritics and special character removal
- Base64 encode/decode
- And many more!

## Installation
Add the `StringExtension` project to your solution or include the `StringExtensions.cs` file in your project.

## Usage
Add the following using directive:

```csharp
using StringExtension;
```

You can then use the extension methods on any string:

```csharp
string email = "test@example.com";
bool isValid = email.IsEmailAddress();

string slug = "Hello, World!".ToSlug();

int number = "123".ToInt();

string hash = "password".CreateHashSha256();
```

## Target Framework
- .NET Standard 2.0 (compatible with .NET Core, .NET Framework, Mono, Xamarin, Unity, etc.)

## Contributing
Contributions, issues, and feature requests are welcome! Feel free to fork the repository and submit pull requests.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Available Methods

Below is a list of all extension methods provided by this library:

| Method | Description |
|--------|-------------|
| IsNullOrEmpty | Checks if the string is null or empty. |
| IsNullOrWhiteSpace | Checks if the string is null, empty, or consists only of white-space characters. |
| ToTitleCase | Converts the string to title case using the current culture. |
| ToInt | Converts the string to an integer. Returns defaultValue if conversion fails. |
| ToDouble | Converts the string to a double. Returns defaultValue if conversion fails. |
| ToDecimal | Converts the string to a decimal. Returns defaultValue if conversion fails. |
| ToDateTime | Converts the string to a DateTime. Returns defaultValue if conversion fails. |
| ToBool | Converts the string to a boolean. Returns defaultValue if conversion fails. |
| ToGuid | Converts the string to a Guid. Returns Guid.Empty if conversion fails. |
| IsDateTime | Checks if the string can be parsed to DateTime with the given format. |
| ToInt32 | Converts the string to a 32-bit signed integer. Returns defaultValue if conversion fails. |
| ToInt64 | Converts the string to a 64-bit signed integer. Returns defaultValue if conversion fails. |
| ToInt16 | Converts the string to a 16-bit signed integer. Returns defaultValue if conversion fails. |
| ToBoolean | Converts the string to a boolean. Returns defaultValue if conversion fails. |
| ToBytes | Converts the string to a byte array using UTF8 encoding. |
| IsInteger | Checks if the string is a valid integer (Int32). |
| IsNumeric | Checks if the string is a valid floating point number. |
| IsAlpha | Checks if the string contains only Unicode letters. |
| IsAlphaNumeric | Checks if the string contains only Unicode letters and digits. |
| IsValidIPv4 | Checks if the string is a valid IPv4 address. |
| IsEmailAddress | Checks if the string is a valid email address. |
| Truncate | Truncates the string to the specified length and appends trailingText if truncated. |
| Capitalize | Capitalizes the first letter of each word in the string. |
| FirstCharacter | Gets the first character of the string, or '\0' if string is null or empty. |
| LastCharacter | Gets the last character of the string, or '\0' if string is null or empty. |
| Replace | Replaces all occurrences of the specified characters with an empty string. |
| RemoveChars | Removes all specified characters from the string. |
| Reverse | Reverses the string. |
| CountOccurrences | Counts the number of occurrences of a substring in the string. |
| EndsWithIgnoreCase | Checks if the string ends with the specified value, ignoring case. |
| StartsWithIgnoreCase | Checks if the string starts with the specified value, ignoring case. |
| DoesNotStartWith | Checks if the string does not start with the specified prefix. |
| DoesNotEndWith | Checks if the string does not end with the specified suffix. |
| AppendSuffixIfMissing | Appends the suffix if the string does not already end with it. |
| AppendPrefixIfMissing | Appends the prefix if the string does not already start with it. |
| Left | Returns the left part of the string with the specified length. |
| Right | Returns the right part of the string with the specified length. |
| IsNull | Checks if the string is null. |
| IsMinLength | Checks if the string length is at least the specified minimum. |
| IsMaxLength | Checks if the string length is at most the specified maximum. |
| IsLength | Checks if the string length is between the specified minimum and maximum. |
| GetLength | Gets the length of the string, returns 0 if null. |
| GetEmptyStringIfNull | Returns an empty string if the value is null. |
| GetDefaultIfEmpty | Returns the default value if the string is null or empty. |
| SplitTo | Splits the string by the given separator and converts each element to type T. |
| ToEnum | Converts the string to the specified Enum type. Returns default(T) if conversion fails. |
| Format | Formats the string with the given arguments. |
| RemovePrefix | Removes the specified prefix from the string if present. |
| RemoveSuffix | Removes the specified suffix from the string if present. |
| CreateHashSha512 | Creates a SHA512 hash of the string and returns as a hex string. |
| CreateHashSha256 | Creates a SHA256 hash of the string and returns as a hex string. |
| QueryStringToDictionary | Converts a query string to a dictionary of key-value pairs. |
| ReverseSlash | Reverses all backslashes and forward slashes in the string. |
| ReplaceLineFeeds | Replaces all line feeds (\n) with the specified replacement. |
| GetByteSize | Gets the byte size of the string using the specified encoding (default UTF8). |
| ToTextElements | Converts the string to an enumerable collection of text elements (grapheme clusters). |
| ParseStringToCsv | Escapes the string for CSV output by wrapping in quotes and escaping quotes. |
| ContainsIgnoreCase | Checks if the string contains the specified substring, ignoring case. |
| EqualsIgnoreCase | Checks if the string equals the specified string, ignoring case. |
| HasLength | Checks if the string has the specified length. |
| IsGuid | Checks if the string is a valid Guid. |
| IsLower | Checks if all characters in the string are lowercase. |
| IsUpper | Checks if all characters in the string are uppercase. |
| IsAscii | Checks if all characters in the string are ASCII. |
| IsBase64String | Checks if the string is a valid Base64 string. |
| IsHex | Checks if the string is a valid hexadecimal string. |
| IsUrl | Checks if the string is a valid URL. |
| IsPhoneNumber | Checks if the string is a valid phone number (basic international format). |
| IsPalindrome | Checks if the string is a palindrome. |
| IsJson | Checks if the string is a valid JSON (basic check). |
| RemoveDiacritics | Removes diacritics (accent marks) from the string. |
| RemoveSpecialCharacters | Removes all special characters from the string, leaving only letters and digits. |
| OnlyDigits | Returns only the digits from the string. |
| OnlyLetters | Returns only the letters from the string. |
| OnlyLettersOrDigits | Returns only the letters and digits from the string. |
| CollapseWhitespace | Collapses multiple whitespace characters into a single space. |
| NormalizeLineEndings | Normalizes all line endings in the string to \n. |
| ToSlug | Converts the string to a URL-friendly slug. |
| Repeat | Repeats the string n times. |
| PadLeftSafe | Pads the string on the left to the specified total length, safe for null values. |
| PadRightSafe | Pads the string on the right to the specified total length, safe for null values. |
| SurroundWith | Surrounds the string with the specified prefix and suffix. |
| RemoveWhiteSpace | Removes all whitespace from the string. |
| RemoveNumbers | Removes all numeric characters from the string. |
| ToBase64 | Converts the string to a Base64 encoded string using UTF8 encoding. |
| FromBase64 | Decodes a Base64 encoded string to its original string using UTF8 encoding. |