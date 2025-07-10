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