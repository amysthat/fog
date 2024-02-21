using System;
using System.Collections.Generic;

namespace fog;

public static class Memory
{
    public static Dictionary<Guid, Object> objects;

    public static void Initialize()
    {
        objects = new Dictionary<Guid, Object>();

        Logging.Info(nameof(Memory), "Initialized.");
    }

    internal static void Add(Object @object)
    {
        objects.Add(@object.GUID, @object);
        Logging.Info($"Added object {@object.GUID}");
    }

    public static void Allocate(Object @object)
    {
        @object.GUID = Guid.NewGuid();
        Add(@object);
    }

    public static T Allocate<T>() where T : Object
    {
        T @object = (T) Activator.CreateInstance(typeof(T));
        Allocate(@object);

        return @object;
    }

    public static void Free(Guid guid)
    {
        objects.Remove(guid);
    }

    public static void Free(Object @object)
    {
        Free(@object.GUID);
    }

    public static Object Get(Guid guid) => objects[guid];

    public static T Get<T>(Guid guid) where T : Object => (T) objects[guid];
}