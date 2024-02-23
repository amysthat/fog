using Microsoft.Xna.Framework;
using System;

namespace fog.Entities;

public class Entity : Object
{
    public string Name { get; set; }
    public Vector2 Position { get; set; }
    public ComponentList Components { get; set; }

    internal void Initialize(string name, Vector2 position)
    {
        Name = name;
        Position = position;
        Components = new();
    }

    public override void UpdateGUIDs(Guid newGuid)
    {
        base.UpdateGUIDs(newGuid);

        foreach (var component in Components)
        {
            component.entity = Reference<Entity>.From(this);
        }
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
        foreach (var component in Components)
        {
            component.OnDestroy();
        }
    }
}