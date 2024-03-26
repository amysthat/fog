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
            var log = PrependMessageData() + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(log);
        }

        public static void Warning(string message)
        {
            var log = PrependMessageData() + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(log);
        }

        public static void Log(string message)
        {
            var log = PrependMessageData() + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(log);
        }

        internal static void Debug(string message)
        {
#if DEBUG
            var log = PrependMessageData() + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(log);
#endif
        }

        private static string PrependMessageData()
        {
            var method = new StackTrace().GetFrame(2)!.GetMethod();
            var className = method!.ReflectedType!.Name;
            var isPlayer = method.ReflectedType.Assembly == Assemblies.Player;

            string data = $"[{DateTime.Now}] ";

            if (isPlayer)
                data += "[Player] ";

            data += $"({className}) ";

            return data;
        }
    }
}
