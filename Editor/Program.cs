using fog.Memory;

namespace Editor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            MemoryManager.Initialize();
            var main = new ProjectSelect();
            main.FormClosed += new FormClosedEventHandler(FormClosed!);
            main.Show();
            Application.Run();
        }

        static void FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= FormClosed!;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0]!.FormClosed += FormClosed!;
        }
    }
}