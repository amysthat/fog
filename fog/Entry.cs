using System;
using System.IO;

namespace fog
{
    public static class Entry
    {
        public static void Run()
        {
            try
            {
                using var game = new fogEngine();
                game.Run();
            }
            catch (Exception ex)
            {
                Logging.Error(ex.ToString());

#if RELEASE
                if (!Directory.Exists("crashes"))
                    Directory.CreateDirectory("crashes");

                string log_path = $"crashes\\{DateTime.Now.ToString().Replace(':', '.')}.log";

                File.WriteAllText(log_path, Logging.History.ToString());

                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
#elif DEBUG
                throw;
#endif
            }
        }
    }
}