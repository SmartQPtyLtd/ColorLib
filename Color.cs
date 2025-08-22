using System;
using static OpenColorLib.Colors;

namespace OpenColorLib;

public sealed record Color
{
    public Color(string hex, bool isWebHex, string? name = null)
    {
        var useHex = !isWebHex ? SystemHexToWebHex(hex) : hex;

        SystemHex = WebHexToSystemHex(useHex);

        WebHex = IsValidHex(in useHex) ? useHex.ToUpper() : throw HexStringError;

        Rgba = WebHexToRgba(useHex);

        Name = !string.IsNullOrWhiteSpace(name) ? name : string.Concat('#', WebHex);

        DisplayName = !string.IsNullOrWhiteSpace(name) ? SplitPascalCase(name) : Name;

        var byteArray = RgbaToArray(Rgba);

        ColorFamily = GetColorFamily(byteArray);

        IsTransparent = byteArray[3] < 1;
    }

    public Color(string rgba)
    {
        var byteArray = RgbaToArray(rgba);

        string hexString = Convert.ToHexString(byteArray);

        SystemHex = WebHexToSystemHex(hexString);

        WebHex = IsValidHex(in hexString) ? hexString.ToUpper() : throw HexStringError;

        Rgba = WebHexToRgba(hexString);

        Name = string.Concat('#', WebHex);

        DisplayName = Name;

        ColorFamily = GetColorFamily(byteArray);

        IsTransparent = byteArray[3] < 1;
    }

    public readonly string? Name;

    public readonly string? DisplayName;

    public readonly string SystemHex;

    public readonly string WebHex;

    public readonly string Rgba;

    public readonly string ColorFamily;

    public readonly bool IsTransparent;
}