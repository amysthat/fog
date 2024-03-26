using System;
using System.Text;

namespace fog
{
    public static class Logging
    {
        internal static StringBuilder History { get; private set; } = new StringBuilder();

        #region Error
        public static void Error(string message)
        {
            Error("Application", message);
        }

        internal static void Error(string category, string message)
        {
            var log = PrependMessageTime(category) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(log);
        }
        #endregion

        #region Warning
        public static void Warning(string message)
        {
            Success("Application", message);
        }

        internal static void Warning(string category, string message)
        {
            var log = PrependMessageTime(category) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(log);
        }
        #endregion

        #region Success
        public static void Success(string message)
        {
            Success("Application", message);
        }

        internal static void Success(string category, string message)
        {
            var log = PrependMessageTime(category) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(log);
        }
        #endregion

        #region Info
        public static void Info(string message)
        {
            Info("Application", message);
        }

        internal static void Info(string category, string message)
        {
            var log = PrependMessageTime(category) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(log);
        }
        #endregion

        #region Debug
        public static void Debug(string message)
        {
            Debug("Application", message);
        }

        internal static void Debug(string category, string message)
        {
#if DEBUG
            var log = PrependMessageTime(category) + message;

            History.AppendLine(log);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(log);
#endif
        }
        #endregion

        private static string PrependMessageTime(string category)
        {
            return $"[{DateTime.Now}] ({category}) ";
        }
    }
}
