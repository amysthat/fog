using System;
using System.Text.Json.Serialization;

namespace fog.Memory;

/// <summary>
/// Be sure to call <see cref="MemoryManager.Add(Object)"/> if you instantiate manually.
/// </summary>
public class Object : IJsonOnDeserialized
{
    public Guid GUID { get; set; }

    public virtual void UpdateGUIDs(Guid newGuid)
    {
        MemoryManager.Remove(this);
        GUID = newGuid;
    }

    public virtual void OnDeserialized()
    {
        Logging.Debug($"Object deserialized. GUID: " + GUID);

        MemoryManager.Add(this);
    }
}