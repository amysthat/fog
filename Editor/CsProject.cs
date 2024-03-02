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

        BuildCsProject(projectName);
    }

    public static void BuildCsProject(string projectName)
    {
        RunCmdCommand("cs_project", $"title C# Project Build && echo off && cls && dotnet build \"{projectName}.csproj\" && echo Press any key to exit... && pause>nul");
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

    public static string GetDebugBuildDllPath(string projectName)
    {
        return Path.Combine(EditorApplication.ProjectPath!, "cs_project", "bin", "Debug", "net7.0", $"{projectName}.dll");
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

    private static void RunCmdCommand(string csProjName, string arguments, bool waitForExit = true)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = @"cmd";
        startInfo.WorkingDirectory = Path.Combine(EditorApplication.ProjectPath!, csProjName);
        startInfo.Arguments = "/c " + arguments;

        var process = Process.Start(startInfo)!;

        if (waitForExit)
            process.WaitForExit();
    }
}
