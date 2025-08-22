using System;

namespace OpenColorLib;

public sealed record Color
{
    public Color(string name, string hex, bool isWebHex)
    {
        string useHex;
        if (!isWebHex)
            useHex = Colors.SystemHexToWebHex(hex);
        else useHex = hex;

        Name = !string.IsNullOrWhiteSpace(name) ? name :
        throw new ArgumentException("Name cannot be null or empty.");

        DisplayName = !string.IsNullOrWhiteSpace(name) ? Colors.SplitPascalCase(name) :
        throw new ArgumentException("Name cannot be null or empty.");

        SystemHex = Colors.WebHexToSystemHex(useHex);

        WebHex = Colors.IsValidHex(in useHex) ? useHex.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHexToRgba(useHex);

        var byteArray = Colors.RgbaToArray(Rgba);

        ColorFamily = Colors.GetColorFamily(byteArray);

        IsTransparent = byteArray[3] < 1;
    }

    public Color(string hex, bool isWebHex)
    {
        string useHex;
        if (!isWebHex)
            useHex = Colors.SystemHexToWebHex(hex);
        else useHex = hex;

        SystemHex = Colors.WebHexToSystemHex(useHex);

        WebHex = Colors.IsValidHex(in useHex) ? useHex.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHexToRgba(useHex);

        Name = string.Concat('#', WebHex);

        DisplayName = Name;

        var byteArray = Colors.RgbaToArray(Rgba);

        ColorFamily = Colors.GetColorFamily(byteArray);

        IsTransparent = byteArray[3] < 1;
    }

    public Color(string rgba)
    {
        var byteArray = Colors.RgbaToArray(rgba);

        string hexString = Convert.ToHexString(byteArray);

        SystemHex = Colors.WebHexToSystemHex(hexString);

        WebHex = Colors.IsValidHex(in hexString) ? hexString.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHexToRgba(hexString);

        Name = string.Concat('#', WebHex);

        DisplayName = Name;

        ColorFamily = Colors.GetColorFamily(byteArray);

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