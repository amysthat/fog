using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace fog.Entities;

public static class World
{
    private static List<Entity> Entities { get; set; } = new();

    public static Entity Add(Entity entity)
    {
        var copy = Memory.Clone(entity);
        Entities.Add(copy);
        return copy;
    }

    public static Entity Add(string name = "New Entity", Vector2? position = null)
    {
        if (position is null)
            position = new Vector2(0, 0);

        var entity = Memory.Allocate<Entity>();
        entity.Initialize(name, position.Value);
        Entities.Add(entity);
        return entity;
    }

    public static void Destroy(Entity entity)
    {
        entity.InvokeAllDestroyMethods();
        Entities.Remove(entity);
        Memory.Remove(entity);
    }

    internal static void DestroyAllEntities()
    {
        int count = 0;
        for (; Entities.Count > 0; count++)
        {
            Destroy(Entities[0]);
        }

        Logging.Log($"Destroyed all {count} entities.");
    }
}