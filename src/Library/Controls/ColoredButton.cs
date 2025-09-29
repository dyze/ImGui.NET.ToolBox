using System.Drawing;
using System.Numerics;

namespace ImGuiNET;

/// <summary>
/// A simple colored button
/// </summary>
public static class ColoredButton
{
    /// <summary>
    /// Render the button
    /// Just provide the color in normal mode and the other colors will be automatically determined.
    /// </summary>
    /// <param name="color">Color in normal mode</param>
    /// <param name="text"></param>
    /// <returns>true if button pressed</returns>
    public static bool Run(Color color, string text)
    {
        var vColor = TypeConverters.ColorToVector4(color);

        ImGui.ColorConvertRGBtoHSV(vColor.X, vColor.Y, vColor.Z, out var h, out var s, out var v);

        // brighter
        var brighterRatio = Math.Clamp(v * 1.4f, 0f, 1f);
        ImGui.ColorConvertHSVtoRGB(h, s, brighterRatio, out var r, out var g, out var b);
        var buttonHoveredColor = new Vector4(r, g, b, 1f);

        // darker
        var darkerRatio = Math.Clamp(v * 0.8f, 0f, 1f);
        ImGui.ColorConvertHSVtoRGB(h, s, darkerRatio, out r, out g, out b);
        var buttonActiveColor = new Vector4(r, g, b, 1f);

        ImGui.PushStyleColor(ImGuiCol.Button, vColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, buttonActiveColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, buttonHoveredColor);

        var result = ImGui.Button(text);

        ImGui.PopStyleColor(3);
        return result;
    }
}