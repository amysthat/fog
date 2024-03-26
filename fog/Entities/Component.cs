using System.Text.Json.Serialization;
using fog.Memory;

namespace fog.Entities;

public class Component
{
    [JsonIgnore] public Reference<Entity> entity { get; internal set; }

    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void OnDraw() { }
    public virtual void OnDestroy() { }
}