namespace ImGuiNET;

public enum ImGuiFileDialogType
{
    OpenFile,
    SaveFile
}

public class FileDialogInfo
{
    public string Title;
    public ImGuiFileDialogType Type;

    public string FileName;
    public DirectoryInfo DirectoryPath;
    public string ResultPath;

    public bool RefreshInfo;
    public ulong CurrentIndex;
    public List<FileInfo> CurrentFiles;
    public List<DirectoryInfo> CurrentDirectories;

    public List<Tuple<string, string>> Extensions = [new("*.*", "All files")];
    public int CurrentExtensionIndex = 0;
    public Tuple<string, string> CurrentExtension => Extensions[CurrentExtensionIndex];

    public string ErrorMessage = "";

    public FileDialogInfo()
    {
        CurrentFiles = new List<FileInfo>();
        CurrentDirectories = new List<DirectoryInfo>();
    }
}