using ImGuiNET;


namespace DemoCenter
{
    internal static class Dialogs
    {
        static bool OpenFileDialogIsOpen = false;
        static bool SaveFileDialogIsOpen = false;

        static FileDialogInfo? _fileDialogInfo;
        static string _fileDialogResult = "";

        public static void Render()
        {
            if (!ImGui.CollapsingHeader("Dialogs"))
                return;

            RenderOpenFileDialog();
            RenderSaveFileDialog();
        }


        private static void RenderOpenFileDialog()
        {
            if (ImGui.TreeNode("Open file dialog"))
            {
                if (ImGui.Button("Trigger Open file dialog"))
                {
                    _fileDialogInfo = new()
                    {
                        Title = "Please select a file to open",
                        Type = ImGuiFileDialogType.OpenFile,
                        DirectoryPath = new DirectoryInfo(Directory.GetCurrentDirectory()),
                        FileName = "",
                        Extensions =
                        [
                            new Tuple<string, string>("*.txt", "Text files"),
                            new Tuple<string, string>("*.*", "All files")
                        ]
                    };
                    OpenFileDialogIsOpen = true;
                }

                if (OpenFileDialogIsOpen)
                {
                    if (FileDialog.Run(ref OpenFileDialogIsOpen, _fileDialogInfo))
                    {
                        _fileDialogResult = _fileDialogInfo.ResultPath;
                    }
                }

                ImGui.Text($"Result={_fileDialogResult}");

                ImGui.TreePop();
            }


        }

        private static void RenderSaveFileDialog()
        {
            if (ImGui.TreeNode("Save file dialog"))
            {
                if (ImGui.Button("Trigger Save file dialog"))
                {
                    _fileDialogInfo = new()
                    {
                        Title = "Please select a target file",
                        Type = ImGuiFileDialogType.SaveFile,
                        DirectoryPath = new DirectoryInfo(Directory.GetCurrentDirectory()),
                        FileName = "",
                        Extensions =
                        [
                            new Tuple<string, string>("*.txt", "Text files"),
                            new Tuple<string, string>("*.*", "All files")
                        ]
                    };
                    SaveFileDialogIsOpen = true;
                }

                if (SaveFileDialogIsOpen)
                {
                    if (FileDialog.Run(ref SaveFileDialogIsOpen, _fileDialogInfo))
                    {
                        _fileDialogResult = _fileDialogInfo.ResultPath;
                    }
                }

                ImGui.Text($"Result={_fileDialogResult}");

                ImGui.TreePop();
            }
        }

    }
}
