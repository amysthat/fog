#if RELEASE
using System;
using System.IO;
#endif

namespace fog
{
    public static class Entry
    {
        public static void Run()
        {
#if RELEASE
            try
            {
#endif
            using var game = new fog();
            game.Run();
#if RELEASE
            }
            catch (Exception ex)
            {
                Logging.Error("Crash Detection", ex.ToString());

                if (!Directory.Exists("crashes"))
                    Directory.CreateDirectory("crashes");

                string log_path = $"crashes\\{DateTime.Now.ToString().Replace(':', '.')}.log";

                File.WriteAllText(log_path, Logging.History.ToString());

                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
            }
#endif
        }
    }
}