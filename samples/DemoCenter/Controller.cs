using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace DemoCenter;

internal class Controller
{
    private readonly Vector2 _screenSize = new(1600, 900);

    internal void Run()
    {
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint |
                              ConfigFlags.ResizableWindow); // Enable Multi Sampling Anti Aliasing 4x (if available)

        Raylib.InitWindow((int)_screenSize.X, (int)_screenSize.Y, "ImGui.NET.ToolBox Demo Center");
        rlImGui.Setup();

        Raylib.SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        Raylib.SetTraceLogLevel(TraceLogLevel.None); // disable logging from now on
        Raylib.SetExitKey(KeyboardKey.Null);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            rlImGui.Begin();

            Raylib.ClearBackground(Color.Black);

            ImGui.SetWindowSize(_screenSize / 2, ImGuiCond.Once);
            RenderDemoCenter();

            rlImGui.End();
            Raylib.EndDrawing();
        }

        rlImGui.Shutdown();
    }

    private static void RenderDemoCenter()
    {
        if (ImGui.Begin("Demo Center"))
        {
            Controls.Render();
            Dialogs.Render();
        }

        ImGui.End();
    }


}