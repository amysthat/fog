using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace fog.Entities
{
    public class Entity
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public Dictionary<Type, Component> Components { get; private set; }

        internal Entity(string name, Vector2 position)
        {
            Name = name;
            Position = position;
            Components = new();
        }

        public T AddComponent<T>() where T : Component
        {
            if (HasComponent<T>())
                return GetComponent<T>();

            var type = typeof(T);

            var component = (T) Activator.CreateInstance(type);
            component.entity = this;

            component.OnStart();

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            if (Components.TryGetValue(typeof(T), out var component))
                return (T) component;

            return null;
        }

        public bool HasComponent<T>() where T : Component
        {
            return Components.TryGetValue(typeof(T), out _);
        }
    
        internal void InvokeAllDestroyMethods()
        {
            foreach (var component in Components.Values)
            {
                component.OnDestroy();
            }
        }
    }
}