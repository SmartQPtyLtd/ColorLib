using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenColorLib;

public static class Colors
{
    private static readonly IReadOnlyDictionary<string, (double R, double G, double B)> Anchors = new Dictionary<string, (double R, double G, double B)>()
    {
        { "Dark", (0, 0, 0) },
        { "Pastel", (1, 1, 1) },
        { "Red", (1, 0, 0) },
        { "Green", (0, 1, 0) },
        { "Blue", (0, 0, 1) },
        { "Yellow", (1, 1, 0) },
        { "Aqua", (0, 1, 1) },
        { "Fuchsia", (1, 0, 1) }/*
        { "Gray", (0.5019607843137255, 0.5019607843137255, 0.5019607843137255) },
        { "Light Green", (0.5647058823529412, 0.9333333333333333, 0.5647058823529412) },
        { "Pale Green", (0.596078431372549, 0.984313725490196, 0.596078431372549) },
        { "Light Blue", (0.6784313725490196, 0.8470588235294118, 0.9019607843137255) },
        { "Powder Blue", (0.6901960784313725, 0.8784313725490196, 0.9019607843137255) },
        { "Silver", (0.7529411764705882, 0.7529411764705882, 0.7529411764705882) },
        { "Tan", (0.8235294117647058, 0.7058823529411765, 0.5490196078431373) },
        { "Light Gray", (0.8274509803921568, 0.8274509803921568, 0.8274509803921568) },
        { "Plum", (0.8666666666666667, 0.6274509803921569, 0.8666666666666667) },
        { "Light Cyan", (0.8784313725490196, 1, 1) },
        { "Lavender", (0.9019607843137255, 0.9019607843137255, 0.9803921568627451) },
        { "Violet", (0.9333333333333333, 0.5098039215686274, 0.9333333333333333) },
        { "Khaki", (0.9411764705882353, 0.9019607843137255, 0.5490196078431373) },
        { "Wheat", (0.9607843137254902, 0.8705882352941177, 0.7019607843137254) },
        { "Beige", (0.9607843137254902, 0.9607843137254902, 0.8627450980392157) },
        { "Light Pink", (1, 0.7137254901960784, 0.7568627450980392) },
        { "Pink", (1, 0.7529411764705882, 0.796078431372549) },
        { "Peach", (1, 0.8549019607843137, 0.7254901960784313) },
        { "Ivory", (1, 1, 0.9411764705882353) },
        { "Teal", (0, 0.5019607843137255, 0.5019607843137255) },
        { "Dark Cyan", (0, 0.5450980392156862, 0.5450980392156862) },
        { "Deep Blue", (0, 0.7490196078431373, 1) },
        { "Dark Turquoise", (0, 0.807843137254902, 0.8196078431372549) },
        { "Dodger Blue", (0.11764705882352941, 0.5647058823529412, 1) },
        { "Turquoise", (0.25098039215686274, 0.8784313725490196, 0.8156862745098039) },
        { "Steel Blue", (0.27450980392156865, 0.5098039215686274, 0.7058823529411765) },
        { "Cadet Blue", (0.37254901960784315, 0.6196078431372549, 0.6274509803921569) },
        { "Slate Gray", (0.4392156862745098, 0.5019607843137255, 0.5647058823529412) },
        { "Aquamarine", (0.4980392156862745, 1, 0.8313725490196079) },
        { "Dark Green", (0, 0.39215686274509803, 0) },
        { "Midnight Blue", (0.09803921568627451, 0.09803921568627451, 0.4392156862745098) },
        { "Dim Gray", (0.4117647058823529, 0.4117647058823529, 0.4117647058823529) },
        { "Navy", (0, 0, 0.5019607843137255) },
        { "Royal Blue", (0.2549019607843137, 0.4117647058823529, 0.8823529411764706) },
        { "Indigo", (0.29411764705882354, 0, 0.5098039215686274) },
        { "Slate Blue", (0.41568627450980394, 0.35294117647058826, 0.803921568627451) },
        { "Purple", (0.5019607843137255, 0, 0.5019607843137255) },
        { "Blue Violet", (0.5411764705882353, 0.16862745098039217, 0.8862745098039215) },
        { "Dark Magenta", (0.5450980392156862, 0, 0.5450980392156862) },
        { "Dark Violet", (0.5803921568627451, 0, 0.8274509803921568) },
        { "Dark Orchid", (0.6, 0.19607843137254902, 0.8) },
        { "Medium Violet Red", (0.7803921568627451, 0.08235294117647059, 0.5215686274509804) },
        { "Orchid", (0.8549019607843137, 0.4392156862745098, 0.8392156862745098) },
        { "Deep Pink", (1, 0.0784313725490196, 0.5764705882352941) },
        { "Hot Pink", (1, 0.4117647058823529, 0.7058823529411765) },
        { "Maroon", (0.5019607843137255, 0, 0) },
        { "Dark Red", (0.5450980392156862, 0, 0) },
        { "Saddle Brown", (0.5450980392156862, 0.27058823529411763, 0.07450980392156863) },
        { "Sienna", (0.6274509803921569, 0.3215686274509804, 0.17647058823529413) },
        { "Brown", (0.6470588235294118, 0.16470588235294117, 0.16470588235294117) },
        { "Firebrick", (0.6980392156862745, 0.13333333333333333, 0.13333333333333333) },
        { "Indian Red", (0.803921568627451, 0.3607843137254902, 0.3607843137254902) },
        { "Chocolate", (0.8235294117647058, 0.4117647058823529, 0.11764705882352941) },
        { "Crimson", (0.8627450980392157, 0.0784313725490196, 0.23529411764705882) },
        { "Orange Red", (1, 0.27058823529411763, 0) },
        { "Coral", (1, 0.4980392156862745, 0.3137254901960784) },
        { "Lime", (0, 1, 0) },
        { "Spring Green", (0, 1, 0.4980392156862745) },
        { "Forest Green", (0.13333333333333333, 0.5450980392156862, 0.13333333333333333) },
        { "Sea Green", (0.1803921568627451, 0.5450980392156862, 0.3411764705882353) },
        { "Lime Green", (0.19607843137254902, 0.803921568627451, 0.19607843137254902) },
        { "Lawn Green", (0.48627450980392156, 0.9882352941176471, 0) },
        { "Chartreuse", (0.4980392156862745, 1, 0) },
        { "Olive", (0.5019607843137255, 0.5019607843137255, 0) },
        { "Yellow Green", (0.6039215686274509, 0.803921568627451, 0.19607843137254902) },
        { "Green Yellow", (0.6784313725490196, 1, 0.1843137254901961) },
        { "Goldenrod", (0.8549019607843137, 0.6470588235294118, 0.12549019607843137) },
        { "Sandy Brown", (0.9568627450980393, 0.6431372549019608, 0.3764705882352941) },
        { "Salmon", (0.9803921568627451, 0.5019607843137255, 0.4470588235294118) },
        { "Orange", (1, 0.6470588235294118, 0) },
        { "Gold", (1, 0.8431372549019608, 0) }*/
    }.AsReadOnly();

    public const string AliceBlue = "FFF0F8FF";
    public const string AntiqueWhite = "FFFAEBD7";
    public const string Aqua = "FF00FFFF";
    public const string Aquamarine = "FF7FFFD4";
    public const string Azure = "FFF0FFFF";
    public const string Beige = "FFF5F5DC";
    public const string Bisque = "FFFFE4C4";
    public const string Black = "FF000000";
    public const string BlanchedAlmond = "FFFFEBCD";
    public const string Blue = "FF0000FF";
    public const string BlueViolet = "FF8A2BE2";
    public const string Brown = "FFA52A2A";
    public const string BurlyWood = "FFDEB887";
    public const string CadetBlue = "FF5F9EA0";
    public const string Chartreuse = "FF7FFF00";
    public const string Chocolate = "FFD2691E";
    public const string Coral = "FFFF7F50";
    public const string CornflowerBlue = "FF6495ED";
    public const string Cornsilk = "FFFFF8DC";
    public const string Crimson = "FFDC143C";
    public const string Cyan = "FF00FFFF";
    public const string DarkBlue = "FF00008B";
    public const string DarkCyan = "FF008B8B";
    public const string DarkGoldenrod = "FFB8860B";
    public const string DarkGray = "FFA9A9A9";
    public const string DarkGreen = "FF006400";
    public const string DarkKhaki = "FFBDB76B";
    public const string DarkMagenta = "FF8B008B";
    public const string DarkOliveGreen = "FF556B2F";
    public const string DarkOrange = "FFFF8C00";
    public const string DarkOrchid = "FF9932CC";
    public const string DarkRed = "FF8B0000";
    public const string DarkSalmon = "FFE9967A";
    public const string DarkSeaGreen = "FF8FBC8F";
    public const string DarkSlateBlue = "FF483D8B";
    public const string DarkSlateGray = "FF2F4F4F";
    public const string DarkTurquoise = "FF00CED1";
    public const string DarkViolet = "FF9400D3";
    public const string DeepPink = "FFFF1493";
    public const string DeepSkyBlue = "FF00BFFF";
    public const string DimGray = "FF696969";
    public const string DodgerBlue = "FF1E90FF";
    public const string Firebrick = "FFB22222";
    public const string FloralWhite = "FFFFFAF0";
    public const string ForestGreen = "FF228B22";
    public const string Fuchsia = "FFFF00FF";
    public const string Gainsboro = "FFDCDCDC";
    public const string GhostWhite = "FFF8F8FF";
    public const string Gold = "FFFFD700";
    public const string Goldenrod = "FFDAA520";
    public const string Gray = "FF808080";
    public const string Green = "FF008000";
    public const string GreenYellow = "FFADFF2F";
    public const string Honeydew = "FFF0FFF0";
    public const string HotPink = "FFFF69B4";
    public const string IndianRed = "FFCD5C5C";
    public const string Indigo = "FF4B0082";
    public const string Ivory = "FFFFFFF0";
    public const string Khaki = "FFF0E68C";
    public const string Lavender = "FFE6E6FA";
    public const string LavenderBlush = "FFFFF0F5";
    public const string LawnGreen = "FF7CFC00";
    public const string LemonChiffon = "FFFFFACD";
    public const string LightBlue = "FFADD8E6";
    public const string LightCoral = "FFF08080";
    public const string LightCyan = "FFE0FFFF";
    public const string LightGoldenrodYellow = "FFFAFAD2";
    public const string LightGray = "FFD3D3D3";
    public const string LightGreen = "FF90EE90";
    public const string LightPink = "FFFFB6C1";
    public const string LightSalmon = "FFFFA07A";
    public const string LightSeaGreen = "FF20B2AA";
    public const string LightSkyBlue = "FF87CEFA";
    public const string LightSlateGray = "FF778899";
    public const string LightSteelBlue = "FFB0C4DE";
    public const string LightYellow = "FFFFFFE0";
    public const string Lime = "FF00FF00";
    public const string LimeGreen = "FF32CD32";
    public const string Linen = "FFFAF0E6";
    public const string Magenta = "FFFF00FF";
    public const string Maroon = "FF800000";
    public const string MediumAquamarine = "FF66CDAA";
    public const string MediumBlue = "FF0000CD";
    public const string MediumOrchid = "FFBA55D3";
    public const string MediumPurple = "FF9370DB";
    public const string MediumSeaGreen = "FF3CB371";
    public const string MediumSlateBlue = "FF7B68EE";
    public const string MediumSpringGreen = "FF00FA9A";
    public const string MediumTurquoise = "FF48D1CC";
    public const string MediumVioletRed = "FFC71585";
    public const string MidnightBlue = "FF191970";
    public const string MintCream = "FFF5FFFA";
    public const string MistyRose = "FFFFE4E1";
    public const string Moccasin = "FFFFE4B5";
    public const string NavajoWhite = "FFFFDEAD";
    public const string Navy = "FF000080";
    public const string OldLace = "FFFDF5E6";
    public const string Olive = "FF808000";
    public const string OliveDrab = "FF6B8E23";
    public const string Orange = "FFFFA500";
    public const string OrangeRed = "FFFF4500";
    public const string Orchid = "FFDA70D6";
    public const string PaleGoldenrod = "FFEEE8AA";
    public const string PaleGreen = "FF98FB98";
    public const string PaleTurquoise = "FFAFEEEE";
    public const string PaleVioletRed = "FFDB7093";
    public const string PapayaWhip = "FFFFEFD5";
    public const string PeachPuff = "FFFFDAB9";
    public const string Peru = "FFCD853F";
    public const string Pink = "FFFFC0CB";
    public const string Plum = "FFDDA0DD";
    public const string PowderBlue = "FFB0E0E6";
    public const string Purple = "FF800080";
    public const string Red = "FFFF0000";
    public const string RosyBrown = "FFBC8F8F";
    public const string RoyalBlue = "FF4169E1";
    public const string SaddleBrown = "FF8B4513";
    public const string Salmon = "FFFA8072";
    public const string SandyBrown = "FFF4A460";
    public const string SeaGreen = "FF2E8B57";
    public const string SeaShell = "FFFFF5EE";
    public const string Sienna = "FFA0522D";
    public const string Silver = "FFC0C0C0";
    public const string SkyBlue = "FF87CEEB";
    public const string SlateBlue = "FF6A5ACD";
    public const string SlateGray = "FF708090";
    public const string Snow = "FFFFFAFA";
    public const string SpringGreen = "FF00FF7F";
    public const string SteelBlue = "FF4682B4";
    public const string Tan = "FFD2B48C";
    public const string Teal = "FF008080";
    public const string Thistle = "FFD8BFD8";
    public const string Tomato = "FFFF6347";
    public const string Transparent = "00FFFFFF";
    public const string Turquoise = "FF40E0D0";
    public const string Violet = "FFEE82EE";
    public const string Wheat = "FFF5DEB3";
    public const string White = "FFFFFFFF";
    public const string WhiteSmoke = "FFF5F5F5";
    public const string Yellow = "FFFFFF00";
    public const string YellowGreen = "FF9ACD32";
    public static readonly IReadOnlyCollection<Color> ColorList = SortedColors();
    public static readonly ArgumentException HexStringError = new("Color must be in RGBA format with 8 characters.");
    private const double Divider = 0.00392156862745098d;

    public static Dictionary<Color, int> ColorCountList(string path)
    {
        Dictionary<Color, int> Count = [];
        // Load the image
        using (Image<Rgba32> image = Image.Load<Rgba32>(path))
        {
            // Access pixel data using ProcessPixelRows
            image.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var pixelRow = accessor.GetRowSpan(y);

                    for (int x = 0; x < accessor.Width; x++)
                    {
                        Rgba32 pixel = pixelRow[x];

                        Color color = new(pixel.ToString());

                        if (Count.TryGetValue(color, out int value))
                            Count[color] = ++value;
                        else Count.Add(color, 1);

                        /*
                        byte red = pixel.R;
                        byte green = pixel.G;
                        byte blue = pixel.B;
                        byte alpha = pixel.A;

                        // Print pixel information (optional)
                        Console.WriteLine($"Pixel at ({x}, {y}): R={red}, G={green}, B={blue}, A={alpha}");*/
                    }
                }
            });
        }

        return Count;
    }

    public static string GetColorFamily(byte[] rgba)
    {
        var r = rgba[0] / 255.0d;
        var g = rgba[1] / 255.0d;
        var b = rgba[2] / 255.0d;

        string closest = "Dark";
        double minDistance = double.MaxValue;

        foreach (var kvp in Anchors)
        {
            var (ar, ag, ab) = kvp.Value;
            double distance = Math.Sqrt(
                Math.Pow(r - ar, 2) +
                Math.Pow(g - ag, 2) +
                Math.Pow(b - ab, 2)
            );

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = kvp.Key;
            }
        }

        return closest;
    }

    public static List<Color> GetThemeColors(in Dictionary<Color, int> colorCountList, int count = 4)
    {
        List<Color> Theme = [];
        List<string> shortList = [];
        foreach (var color in colorCountList.OrderByDescending(x => x.Value))
        {
            if (color.Key.IsTransparent)
                continue;

            if (Theme.Count > (count - 1))
                break;

            if (shortList.Contains(color.Key.ColorFamily))
                continue;

            shortList.Add(color.Key.ColorFamily);
            Theme.Add(color.Key);
        }

        shortList.Clear();
        return Theme;
    }

    public static bool IsValidHexString(in string hexString) => hexString.Length == 8 && hexString.All(Uri.IsHexDigit);

    public static byte[] RgbaStringToArray(string rgba)
    {
        if ((!rgba.StartsWith("Rgba32(") || !rgba.StartsWith("rgba(")) && !rgba.EndsWith(')') && !rgba.Contains(','))
            throw new ArgumentException("RGBA string must be a valid 'Rgba32' or 'rgba' value.");
        //(153, 60, 180, 255)

        string[] rgbaStringArray = rgba.Replace("Rgba32", string.Empty)
            .Replace("rgba", string.Empty)
            .Replace("(", string.Empty)
            .Replace(")", string.Empty)
            .Split(',', StringSplitOptions.TrimEntries);

        if (rgbaStringArray.Length != 4)
            throw new ArgumentException("RGBA string must contain exactly four values.");

        foreach (string value in rgbaStringArray)
        {
            if (!byte.TryParse(value, out _))
                throw new ArgumentException("RGBA values must be valid byte values (0-255).");
        }

        byte[] byteArray = new byte[4];

        for (int i = 0; i < byteArray.Length; i++)
            byteArray[i] = byte.Parse(rgbaStringArray[i]);

        return byteArray;
    }

    public static string SplitPascalCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new Exception("Input null or whitespace");

        string output = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0)
            {
                output += input[i];
                continue;
            }

            if (char.IsUpper(input[i]))
                output += string.Concat(' ', input[i]);
            else output += input[i];
        }

        return output;
    }

    public static string SystemHex_WebHex(string systemHex)
    {
        if (IsValidHexString(in systemHex))
            return string.Concat(systemHex.ToUpper()[2..], systemHex.ToUpper()[..2]);

        throw HexStringError;
    }

    public static string WebHex_RGBA(string webHexColor)
    {
        if (IsValidHexString(in webHexColor))
        {
            var rgba = webHexColor.ToUpper();
            return string.Concat("rgba(", ConvertDoubleHexToDigit(rgba[..2]), ',',
                ConvertDoubleHexToDigit(rgba.Substring(2, 2)), ',',
                ConvertDoubleHexToDigit(rgba.Substring(4, 2)), ',',
                ToAlphaValue(rgba[6..]),
                ')');
        }

        throw HexStringError;
    }

    public static string WebHex_SystemHex(string webHexColor)
    {
        if (IsValidHexString(in webHexColor))
            return string.Concat(webHexColor.ToUpper()[6..], webHexColor.ToUpper()[..6]);

        throw HexStringError;
    }

    private static int ConvertDoubleHexToDigit(string doubleHex) => Convert.ToInt32(doubleHex, 16);

    private static IEnumerable<Color> Initialize()
    {
        var fields = typeof(Colors).GetFields();
        foreach (var field in fields)
        {
            if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                yield return new Color(field.Name, field!.GetValue(typeof(Colors))!.ToString()!, false);
        }
    }

    private static ReadOnlyCollection<Color> SortedColors()
    {
        List<Color> list = [.. Initialize()];
        List<Color> sortedList = [];
        List<Color> tList = [];
        foreach (var groupedList in list.GroupBy(x => x.ColorFamily))
        {
            tList = [.. groupedList];
            tList.Sort(new AlphanumericComparer());
            sortedList.AddRange(tList);
            tList.Clear();
        }

        return sortedList.AsReadOnly();
    }

    private static double ToAlphaValue(string doubleHex) => Convert.ToInt16(doubleHex, 16) * Divider;

    public class AlphanumericComparer : IComparer<Color>
    {
        public int Compare(Color? x, Color? y)
        {
            if (x is null || y is null)
                return 0;

            bool xIsNumeric = IsFullyNumeric(x.WebHex);
            bool yIsNumeric = IsFullyNumeric(y.WebHex);

            // Numbers come before letters
            if (xIsNumeric && !yIsNumeric) return -1;
            if (!xIsNumeric && yIsNumeric) return 1;

            // If both are same type, use ordinal comparison
            return string.CompareOrdinal(x.WebHex, y.WebHex);
        }

        private static bool IsFullyNumeric(string input)
        {
            foreach (char c in input)
                if (!char.IsDigit(c)) return false;
            return true;
        }
    }
}