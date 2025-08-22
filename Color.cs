using System;

namespace OpenColorLib;

public sealed record Color
{
    public Color(string name, string hex, bool isWebHex)
    {
        string useHex;
        if (!isWebHex)
            useHex = Colors.SystemHex_WebHex(hex);
        else useHex = hex;

        Name = !string.IsNullOrWhiteSpace(name) ? name :
        throw new ArgumentException("Name cannot be null or empty.");

        DisplayName = !string.IsNullOrWhiteSpace(name) ? Colors.SplitPascalCase(name) :
        throw new ArgumentException("Name cannot be null or empty.");

        SystemHex = Colors.WebHex_SystemHex(useHex);

        WebHex = Colors.IsValidHexString(in useHex) ? useHex.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHex_RGBA(useHex);

        ByteArray = Colors.RgbaStringToArray(Rgba);

        ColorFamily = Colors.GetColorFamily(ByteArray);

        IsTransparent = ByteArray[3] < 1;
    }

    public Color(string hex, bool isWebHex)
    {
        string useHex;
        if (!isWebHex)
            useHex = Colors.SystemHex_WebHex(hex);
        else useHex = hex;

        SystemHex = Colors.WebHex_SystemHex(useHex);

        WebHex = Colors.IsValidHexString(in useHex) ? useHex.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHex_RGBA(useHex);

        Name = string.Concat('#', WebHex);

        DisplayName = Name;

        ByteArray = Colors.RgbaStringToArray(Rgba);

        ColorFamily = Colors.GetColorFamily(ByteArray);

        IsTransparent = ByteArray[3] < 1;
    }

    public Color(string rgba)
    {
        ByteArray = Colors.RgbaStringToArray(rgba);

        string hexString = Convert.ToHexString(ByteArray);

        SystemHex = Colors.WebHex_SystemHex(hexString);

        WebHex = Colors.IsValidHexString(in hexString) ? hexString.ToUpper() : throw Colors.HexStringError;

        Rgba = Colors.WebHex_RGBA(hexString);

        Name = string.Concat('#', WebHex);

        DisplayName = Name;

        ColorFamily = Colors.GetColorFamily(ByteArray);

        IsTransparent = ByteArray[3] < 1;
    }

    public readonly string? Name;

    public readonly string? DisplayName;

    public readonly byte[] ByteArray;

    public readonly string SystemHex;

    public readonly string WebHex;

    public readonly string Rgba;

    public readonly string ColorFamily;

    public readonly bool IsTransparent;
}