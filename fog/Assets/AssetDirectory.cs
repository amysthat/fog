using System.IO;

namespace fog.Assets;

public static class AssetDirectory
{
    private static string[] files = new string[0];

    internal static void Initialize()
    {
        var actualFiles = Directory.GetFiles("data");
        files = new string[actualFiles.Length];

        for (int i = 0; i < actualFiles.Length; i++)
        {
            files[i] = Path.GetFileName(actualFiles[i]);
        }

        Logging.Log("Initialized.");
    }

    /// <param name="file">File name with extension.</param>
    public static byte[] ReadAllBytes(string file) => File.ReadAllBytes(PrependDataPath(file));

    /// <param name="file">File name with extension.</param>
    public static string ReadAllText(string file) => File.ReadAllText(PrependDataPath(file));

    /// <param name="file">File name with extension.</param>
    public static bool Exists(string file) => File.Exists(PrependDataPath(file));

    public static string[] GetFiles() => files;

    private static string PrependDataPath(string path) => Path.Combine("data", path);
}
