using System;

namespace fog.Memory;

public class Reference<T> where T : Object
{
    public Guid GUID { get; set; }

    public T Get() => MemoryManager.Get<T>(GUID);
    public bool IsNull() => GUID == Guid.Empty;

    public static implicit operator T(Reference<T> reference) => reference.Get();

    public static Reference<T> Null() => new Reference<T> { GUID = Guid.Empty };
    public static Reference<T> From(Guid guid) => new Reference<T> { GUID = guid };
    public static Reference<T> From(Object @object) => new Reference<T> { GUID = @object.GUID };
}