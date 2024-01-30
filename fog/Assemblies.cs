using System;
using System.Reflection;

namespace fog
{
    internal static class Assemblies
    {
        public static Assembly Self { get; private set; } = Assembly.GetExecutingAssembly();
        public static Assembly Player { get; private set; }

        public static void LoadPlayerAssembly(byte[] content)
        {
            try
            {
                Player = Assembly.Load(content);
                Logging.Success(nameof(Assemblies), $"Successfully loaded player assembly: " + Player.GetName().Name);
            }
            catch
            {
                throw new DllNotFoundException("Could not load player assembly!");
            }
        }
    }
}