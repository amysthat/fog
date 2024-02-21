namespace fog.Entities;

public class Component
{
    public Reference<Entity> entity { get; internal set; }

    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void OnDraw() { }
    public virtual void OnDestroy() { }
}