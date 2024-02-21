using Microsoft.Xna.Framework;
using System;

namespace fog.Entities
{
    public class Entity : Object
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public ComponentList Components { get; private set; }

        public Entity() : base(false)
        {
            Memory.Add(this);
        }

        internal Entity(string name, Vector2 position) : base(true)
        {
            Name = name;
            Position = position;
            Components = new();
        }

        public T AddComponent<T>() where T : Component
        {
            Components.AddComponent<T>(this);

            return Components.GetComponent<T>();
        }

        public T GetComponent<T>() where T : Component => Components.GetComponent<T>();

        public bool HasComponent<T>() where T : Component => Components.HasComponent<T>();
    
        internal void InvokeAllDestroyMethods()
        {
            foreach (var component in Components.Components)
            {
                component.OnDestroy();
            }
        }
    }
}