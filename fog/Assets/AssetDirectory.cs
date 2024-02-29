using System.IO;

namespace fog.Assets;

public static class AssetDirectory
{
    private static string[] files = new string[0];

    internal static string AssetPath = "data";

    internal static void Initialize()
    {
        var actualFiles = Directory.GetFiles(AssetPath);
        files = new string[actualFiles.Length];

        for (int i = 0; i < actualFiles.Length; i++)
        {
            files[i] = Path.GetFileName(actualFiles[i]);
        }

        Logging.Log("Initialized.");
    }

    /// <param name="file">File name with extension.</param>
    public static byte[] ReadAllBytes(string file) => File.ReadAllBytes(PrependAssetPath(file));

    /// <param name="file">File name with extension.</param>
    public static string ReadAllText(string file) => File.ReadAllText(PrependAssetPath(file));

    /// <param name="file">File name with extension.</param>
    public static bool Exists(string file) => File.Exists(PrependAssetPath(file));

    public static string[] GetFiles() => files;

    private static string PrependAssetPath(string path) => Path.Combine(AssetPath, path);
}
