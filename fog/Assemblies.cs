using fog.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace fog
{
    internal static class Assemblies
    {
        public static Assembly Self { get; private set; } = Assembly.GetExecutingAssembly();
        public static Assembly Player { get; private set; }

        private static List<MethodInfo> AfterInitializationCallbacks = new();
        private static List<MethodInfo> AfterStartupEntityLoadCallbacks = new();
        private static List<MethodInfo> BeforeStartupEntityLoadCallbacks = new();

        public static void LoadPlayerAssemblyFromProjectSettings()
        {
            var content = AssetDirectory.ReadAllBytes(ProjectSettings.Active.PlayerAssembly + ".dll");
            LoadPlayerAssembly(content);
        }

        public static void LoadPlayerAssembly(byte[] content)
        {
            try
            {
                Player = Assembly.Load(content);
                Logging.Log($"Successfully loaded player assembly: " + Player.GetName().Name);
            }
            catch
            {
                throw new Exception("Could not load player assembly!");
            }
        }

        public static void RetreiveAllInvocationCallbacks()
        {
            int total = 0;

            foreach (var type in Player.GetTypes())
            {
                foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                {
                    var attribute = method.GetCustomAttribute<InvokeOnLoadAttribute>();
                    var isAttributeUsed = attribute is not null;

                    if (isAttributeUsed)
                    {
                        var invocationTime = attribute.InvocationTime;

                        switch (invocationTime)
                        {
                            case InvocationTime.AfterInitialized:
                                AfterInitializationCallbacks.Add(method);
                                break;
                            case InvocationTime.BeforeStartupEntityLoad:
                                BeforeStartupEntityLoadCallbacks.Add(method);
                                break;
                            case InvocationTime.AfterStartupEntityLoad:
                                AfterStartupEntityLoadCallbacks.Add(method);
                                break;
                            default:
                                throw new InvalidOperationException();
                        }

                        total++;
                    }
                }
            }

            Logging.Log($"Invocations registered. (total: {total})");
        }

        public static void CallAllInitializationCallbacks()
        {
            foreach (var callback in AfterInitializationCallbacks)
            {
                callback.Invoke(null, null);
            }

            Logging.Log($"Called all after initialization callbacks. (total: {AfterInitializationCallbacks.Count})");
        }

        public static void CallAllBeforeStartupEntityLoadCallbacks()
        {
            foreach (var callback in BeforeStartupEntityLoadCallbacks)
            {
                callback.Invoke(null, null);
            }

            Logging.Log($"Called all before startup entity load callbacks. (total: {BeforeStartupEntityLoadCallbacks.Count})");
        }

        public static void CallAllAfterStartupEntityLoadCallbacks()
        {
            foreach (var callback in AfterStartupEntityLoadCallbacks)
            {
                callback.Invoke(null, null);
            }

            Logging.Log($"Called all after startup entity load callbacks. (total: {AfterStartupEntityLoadCallbacks.Count})");
        }
    }
}