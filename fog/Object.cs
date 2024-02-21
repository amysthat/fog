using System;

namespace fog;

public class Object
{
    public Guid GUID { get; internal set; }

    /// <summary>
    /// Try using <see cref="Memory.Allocate{T}()"/> or <see cref="Memory.Allocate(Object)"/> instead.
    /// </summary>
    public Object(bool allocate = true)
    {
        if (allocate)
            Memory.Allocate(this);
    }
}