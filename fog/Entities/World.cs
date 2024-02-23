using Microsoft.Xna.Framework;
using System.Collections.Generic;
using fog.Memory;

namespace fog.Entities;

public static class World
{
    private static List<Entity> Entities { get; set; } = new();

    public static Entity Add(Entity entity)
    {
        var copy = MemoryManager.Clone(entity);
        Entities.Add(copy);
        return copy;
    }

    public static Entity Add(string name = "New Entity", Vector2? position = null)
    {
        if (position is null)
            position = new Vector2(0, 0);

        var entity = MemoryManager.Allocate<Entity>();
        entity.Initialize(name, position.Value);
        Entities.Add(entity);
        return entity;
    }

    public static void Destroy(Entity entity)
    {
        entity.InvokeAllDestroyMethods();
        Entities.Remove(entity);
        MemoryManager.Remove(entity);
    }

    internal static void Update()
    {
        foreach (var entity in Entities)
        {
            entity.InvokeAllUpdateMethods();
        }
    }

    internal static void Draw()
    {
        foreach (var entity in Entities)
        {
            entity.InvokeAllDrawMethods();
        }
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