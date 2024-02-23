using System;
using System.Diagnostics;
using System.Text;

namespace fog
{
    public static class Logging
    {
        internal static StringBuilder History { get; private set; } = new StringBuilder();

        public static void Error(string message)
        {
            var method = new StackTrace().GetFrame(1)!.GetMethod();
            var className = method!.ReflectedType!.Name;

            var log = PrependMessageTime(className) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(log);
        }

        public static void Warning(string message)
        {
            var method = new StackTrace().GetFrame(1)!.GetMethod();
            var className = method!.ReflectedType!.Name;

            var log = PrependMessageTime(className) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(log);
        }

        public static void Log(string message)
        {
            var method = new StackTrace().GetFrame(1)!.GetMethod();
            var className = method!.ReflectedType!.Name;

            var log = PrependMessageTime(className) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(log);
        }

        internal static void Debug(string message)
        {
#if DEBUG
            var method = new StackTrace().GetFrame(1)!.GetMethod();
            var className = method!.ReflectedType!.Name;

            var log = PrependMessageTime(className) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(log);
#endif
        }

        private static string PrependMessageTime(string category)
        {
            return $"[{DateTime.Now}] ({category}) ";
        }
    }
}
