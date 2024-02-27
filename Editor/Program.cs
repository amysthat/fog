namespace Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
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