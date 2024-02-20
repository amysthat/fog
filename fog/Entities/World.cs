using fog.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace fog.Nodes
{
    public static class World
    {
        private static List<Entity> Entities { get; set; } = new();

        public static Entity Add(string name = "New Entity", Vector2 position = new Vector2())
        {
            var entity = new Entity(name, position);
            Entities.Add(entity);
            return entity;
        }

        public static void Destroy(Entity entity)
        {
            entity.InvokeAllDestroyMethods();
            Entities.Remove(entity);
        }

        internal static void DestroyAllEntities()
        {
            int count = 0;
            for (; Entities.Count > 0; count++)
            {
                Destroy(Entities[0]);
                count++;
            }

            Logging.Info(nameof(World), $"Destroyed all {count} entities.");
        }
    }
}