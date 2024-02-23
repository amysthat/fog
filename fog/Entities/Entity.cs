using fog.Memory;
using Microsoft.Xna.Framework;
using System;
using Object = fog.Memory.Object;

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
        var component = Components.GetComponent<T>();
        component.OnStart();

        return component;
    }

    public T GetComponent<T>() where T : Component => Components.GetComponent<T>();

    public bool HasComponent<T>() where T : Component => Components.HasComponent<T>();

    internal void InvokeAllStartMethods()
    {
        foreach (var component in Components)
        {
            component.OnStart();
        }
    }

    internal void InvokeAllUpdateMethods()
    {
        foreach (var component in Components)
        {
            component.OnUpdate();
        }
    }

    internal void InvokeAllDrawMethods()
    {
        foreach (var component in Components)
        {
            component.OnDraw();
        }
    }

    internal void InvokeAllDestroyMethods()
    {
        foreach (var component in Components)
        {
            component.OnDestroy();
        }
    }
}