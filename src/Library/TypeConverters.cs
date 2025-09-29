using System.Numerics;


namespace ImGuiNET;

public static class TypeConverters
{

    public static Vector4 ColorToVector4(System.Drawing.Color src)
    {
        return new Vector4(src.R/255f, 
            src.G / 255f, 
            src.B / 255f,
            src.A / 255f);
    }

    public static System.Drawing.Color Vector4ToColor(Vector4 src)
    {
        return System.Drawing.Color.FromArgb((int)(src.W*255), 
            (int)(src.X * 255f), 
            (int)(src.Y * 255f), 
            (int)(src.Z * 255f));
    }
}