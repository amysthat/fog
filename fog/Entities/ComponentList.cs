using System;
using System.Collections.Generic;

namespace fog.Entities
{
    [Serializable]
    public class ComponentList
    {
        public List<string> Types { get; set; } = new();
        public List<Component> Components { get; set; } = new();

        public void AddComponent<T>(Entity entity) where T : Component
        {
            if (HasComponent<T>())
                return;

            var type = typeof(T);
            var instance = (T) Activator.CreateInstance(type);
            instance.entity = Reference<Entity>.From(entity);

            Types.Add(type.FullName);
            Components.Add(instance);
        }

        public bool HasComponent<T>() where T : Component
        {
            var lookingFor = typeof(T).FullName;

            foreach (var type in Types)
            {
                if (type == lookingFor)
                    return true;
            }

            return false;
        }
    
        public T GetComponent<T>() where T : Component
        {
            if (!HasComponent<T>())
                return null;

            var typeName = typeof(T).FullName;

            int index = Types.IndexOf(typeName);
            return (T) Components[index];
        }

        public int Count => Types.Count;
    }
}