using System;

namespace fog.Nodes
{
    public class NodeRefNotFoundException : Exception
    {
        public NodeRefNotFoundException() { }
        public NodeRefNotFoundException(Guid instanceId) : base($"{instanceId} wasn't found.") { }
    }
}