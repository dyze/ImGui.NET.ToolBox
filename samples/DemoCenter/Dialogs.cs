using ImGuiNET;
using Library.Dialogs;


namespace DemoCenter
{
    internal static class Dialogs
    {
        private static bool _openFileDialogIsOpen;
        private static bool _saveFileDialogIsOpen;
        private static bool _selectFolderDialogIsOpen;

        private static FileDialogInfo? _fileDialogInfo;
        private static string _fileDialogResult = "";
        private static string _messageDialogResult = "";

        private static MessageDialog.Configuration? _messageDialogConfiguration;

        public static void Render()
        {
            if (!ImGui.CollapsingHeader("Dialogs"))
                return;

            RenderOpenFileDialog();
            RenderSaveFileDialog();
            RenderSelectFolderDialog();
            RenderMessageDialog();
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
                    _openFileDialogIsOpen = true;
                }

                if (_openFileDialogIsOpen)
                {
                    if (FileDialog.Run(ref _openFileDialogIsOpen, _fileDialogInfo))
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
                    _saveFileDialogIsOpen = true;
                }

                if (_saveFileDialogIsOpen)
                {
                    if (FileDialog.Run(ref _saveFileDialogIsOpen, _fileDialogInfo))
                    {
                        _fileDialogResult = _fileDialogInfo.ResultPath;
                    }
                }

                ImGui.Text($"Result={_fileDialogResult}");

                ImGui.TreePop();
            }
        }

        private static void RenderSelectFolderDialog()
        {
            if (ImGui.TreeNode("Select folder dialog"))
            {
                if (ImGui.Button("Trigger Select folder dialog"))
                {
                    _fileDialogInfo = new()
                    {
                        Title = "Please select a folder",
                        Type = ImGuiFileDialogType.SelectFolder,
                        DirectoryPath = new DirectoryInfo(Directory.GetCurrentDirectory()),
                        DirectoryName = ""
                    };
                    _selectFolderDialogIsOpen = true;
                }

                if (_selectFolderDialogIsOpen)
                {
                    if (FileDialog.Run(ref _selectFolderDialogIsOpen, _fileDialogInfo))
                    {
                        _fileDialogResult = _fileDialogInfo.ResultPath;
                    }
                }

                ImGui.Text($"Result={_fileDialogResult}");

                ImGui.TreePop();
            }
        }

        private static void RenderMessageDialog()
        {
            if (ImGui.TreeNode("Message dialog"))
            {
                if (ImGui.Button("Trigger a Message dialog"))
                {
                    _messageDialogConfiguration = new("Current file has not been saved",
                        "Are you sure you want to continue?",
                        [
                            new MessageDialog.ButtonConfiguration(MessageDialog.ButtonId.Yes, "Yes, I'm sure",
                                _ => YesPressed(),
                                System.Drawing.Color.Red),
                            new MessageDialog.ButtonConfiguration(MessageDialog.ButtonId.No, "No, I changed my mind",
                                null
                            )
                        ]);
                }

                var result = MessageDialog.Run(_messageDialogConfiguration);
                if (result != null)
                {
                    _messageDialogResult = result.Id.ToString();
                    _messageDialogConfiguration = null;
                }

                ImGui.Text($"Result={_messageDialogResult}");

                ImGui.TreePop();
            }
        }

        private static void YesPressed()
        {

        }
    }
}