using System;
using System.Collections.Generic;
using fog.Assets;

namespace fog.Memory;

public static class MemoryManager
{
    public static Dictionary<Guid, Object> objects;

    public static void Initialize()
    {
        objects = new Dictionary<Guid, Object>();

        Logging.Log("Initialized.");
    }

    internal static void Add(Object @object)
    {
        if (objects.TryAdd(@object.GUID, @object))
        {
            Logging.Log($"Added object {@object.GUID}");
        }
    }

    public static void Allocate(Object @object)
    {
        @object.GUID = Guid.NewGuid();
        Add(@object);
    }

    public static T Allocate<T>() where T : Object
    {
        T @object = (T)Activator.CreateInstance(typeof(T));
        Allocate(@object);

        return @object;
    }

    public static void Remove(Guid guid)
    {
        objects.Remove(guid);
    }

    public static void Remove(Object @object)
    {
        Remove(@object.GUID);
    }

    public static Object Get(Guid guid) => objects[guid];

    public static T Get<T>(Guid guid) where T : Object => (T)objects[guid];

    public static T Clone<T>(T @object) where T : Object
    {
        var content = AssetPipeline.Serialization.SerializeContent(@object);
        var newObject = AssetPipeline.Serialization.DeserializeContent<T>(content);
        newObject.UpdateGUIDs(Guid.NewGuid());

        Logging.Log($"Cloning {@object.GUID} -> {newObject.GUID} ({typeof(T).Name})");
        return newObject;
    }
}