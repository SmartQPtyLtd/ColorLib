# OpenColorLib

OpenColorLib is a C# library for working with named colors, color conversions, and color analysis. It provides a comprehensive set of color constants, utilities for converting between color formats, and methods for analyzing images to extract color information.

## Features

- **Named Colors**: Access hundreds of standard color names as constants.
- **Color Conversion**: Convert between RGBA, web hex, and system hex formats.
- **Color Analysis**: Analyze images to count color occurrences and extract theme colors.
- **Color Family Detection**: Classify colors into families (e.g., Red, Blue, Green, etc.).
- **Pascal Case Splitting**: Utility to split PascalCase color names into readable strings.

## Getting Started

### Prerequisites

- .NET 9 or later
- [SixLabors.ImageSharp](https://github.com/SixLabors/ImageSharp) (for image processing)

### Installation

Add a reference to the OpenColorLib project or include it in your solution.

### Usage
## API Overview

- `ColorList`: All named colors as `Color` records.
- `ColorCountList(string path)`: Returns a dictionary of colors and their counts from an image.
- `GetThemeColors(Dictionary<Color, int> colorCountList, int count = 4)`: Returns the most prominent theme colors.
- `GetColorFamily(byte[] rgba)`: Returns the color family for a given RGBA value.
- `IsValidHex(string hex)`: Validates an 8-character RGBA hex string.
- `RgbaStringToArray(string rgba)`: Converts an RGBA string to a byte array.
- `SplitPascalCase(string input)`: Splits PascalCase strings into readable text.
- `SystemHexToWebHex(string systemHex)`: Converts system hex to web hex.
- `WebHexToRgba(string webHex)`: Converts web hex to RGBA string.
- `WebHexToSystemHex(string webHex)`: Converts web hex to system hex.

## License

This project is licensed under the MIT License.

## Acknowledgments

- [SixLabors.ImageSharp](https://github.com/SixLabors/ImageSharp) for image processing.

## Usage example
```csharp
using System;
using static OpenColorLib.Colors;

var Counts = ColorCountList(@"C:\yourimagefile.png");

foreach (var color in GetThemeColors(Counts))
    Console.WriteLine($"{color.DisplayName} : {color.ColorFamily}");
```