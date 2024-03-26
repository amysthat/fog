using System;

namespace fog;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class InvokeOnLoadAttribute : Attribute
{
    public InvocationTime InvocationTime { get; private set; }

    public InvokeOnLoadAttribute(InvocationTime invocationTime)
    {
        InvocationTime = invocationTime;
    }
}

public enum InvocationTime
{
    AfterInitialized,
    BeforeStartupEntityLoad,
    AfterStartupEntityLoad,
}