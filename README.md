# Contrib.Bcl.Ranges

This package polyfills the types required for the C# 8.0 feature [Ranges](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges) on targets lower than `netcoreapp3.0` and `netstandard2.1`. This includes:
- .NET Framework - starting from `net461`
- .NET Standard 2.0 Compatible Runtimes - this includes .NET Core 2.x

## Usage

Add this to your `csproj` file:
```xml
<PackageReference Include="Contrib.Bcl.Ranges" Version="1.0.0-preview8.19405.3" />
```
and add this to the `PropertyGroup`:
```xml
<LangVersion>8.0</LangVersion>
```

Now we can start using this handy new language feature 😀
```csharp
Console.WriteLine("Hello world!"[6..^1]); // world
```
