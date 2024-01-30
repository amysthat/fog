using System;

namespace fog.Nodes
{
    public struct NodeRef
    {
        public Guid InstanceID { get; private set; }

        public NodeRef(Guid instanceId) => InstanceID = instanceId;
        public NodeRef(Node node) => InstanceID = node.InstanceID;

        public Node Get() => World.GetNode(InstanceID);
        public T Get<T>() where T : Node => (T) Get();

        public static implicit operator Node(NodeRef nodeRef) => nodeRef.Get();
    }
}