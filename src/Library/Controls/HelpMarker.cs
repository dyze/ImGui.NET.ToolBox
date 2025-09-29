
namespace ImGuiNET;

/// <summary>
/// Helper to display a little (?) mark which shows a tooltip when hovered.
/// </summary>
public static class HelpMarker
{
    public static void Run(string description)
    {
        ImGui.TextDisabled("(?)");
        if (ImGui.BeginItemTooltip())
        {
            ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
            ImGui.TextUnformatted(description);
            ImGui.PopTextWrapPos();
            ImGui.EndTooltip();
        }
    }
}