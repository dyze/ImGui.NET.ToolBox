using ImGuiNET;


namespace DemoCenter
{
    internal static class Controls
    {
        public static void Render()
        {
            if (!ImGui.CollapsingHeader("Controls"))
                return;

            RenderColoredButton();
        }

        private static void RenderColoredButton()
        {
            if (ImGui.TreeNode("Colored Button"))
            {
                if (ColoredButton.Run(System.Drawing.Color.LimeGreen, "Validate"))
                { }

                ImGui.SameLine();

                if (ColoredButton.Run(System.Drawing.Color.Red, "Erase"))
                { }

                ImGui.TreePop();
            }
        }
    }
}
