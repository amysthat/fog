using System.Diagnostics;

namespace Editor;

public static class CsProject
{
    public static void GenerateCsProject(string projectName)
    {
        var csProjectPath = Path.Combine(EditorApplication.ProjectPath!, "cs_project");

        Directory.CreateDirectory(csProjectPath);
        RunDotNetCommand("cs_project", $"new classlib -n \"{projectName}\" -o .");

        File.Delete(Path.Combine(csProjectPath, "Class1.cs"));

        using (var dlg = new OpenFileDialog())
        {
            dlg.Filter = "fogEngine|*.dll";

            dlg.ShowDialog();

            byte[] content = File.ReadAllBytes(dlg.FileName);
            File.WriteAllBytes(Path.Combine(csProjectPath, "fog.dll"), content);
        }

        File.WriteAllText(Path.Combine(csProjectPath, $"{projectName}.csproj"), Properties.Resources.CSProjContent);

        BuildCsProject();
    }

    public static void BuildCsProject()
    {
        RunDotNetCommand("cs_project", "build");
    }

    public static void OpenCsProject(string projectName)
    {
        var csProjectPath = Path.Combine(EditorApplication.ProjectPath!, "cs_project");

        new Process
        {
            StartInfo = new ProcessStartInfo(Path.Combine(csProjectPath, $"{projectName}.csproj"))
            {
                UseShellExecute = true
            }
        }.Start();
    }

    private static void RunDotNetCommand(string csProjName, string arguments, bool waitForExit = true)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = @"dotnet";
        startInfo.WorkingDirectory = Path.Combine(EditorApplication.ProjectPath!, csProjName);
        startInfo.Arguments = arguments;

        var process = Process.Start(startInfo)!;

        if (waitForExit)
            process.WaitForExit();
    }
}
