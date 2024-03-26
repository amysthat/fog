using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace fog.Nodes
{
    public class Node
    {
        public Guid InstanceID { get; set; }
        public string Name { get; set; } = "New Node";

        public Vector2 Position { get; set; } = new();
        public List<NodeRef> Children { get; set; } = new();
        public NodeRef? Parent { get; set; }

        [YamlIgnore]
        public Vector2 GlobalPosition
        {
            get
            {
                Vector2 position = Position;

                if (Parent is null)
                    return position;

                Node workingNode = Parent;
                while (true)
                {
                    position += workingNode.Position;

                    if (workingNode.Parent is null)
                        break;

                    workingNode = workingNode.Parent;
                }

                return position;
            }
        }

        public void AddChild(NodeRef node)
        {
            node.Get().Reparent(this);
        }

        public void Reparent(NodeRef? node)
        {
            if (Parent.HasValue)
                World.BaseHierarchy.Remove(node.Value);

            Parent?.Get().Children.Remove(new NodeRef(node.Value.InstanceID));
            node.Value.Get().Children.Add(new NodeRef(InstanceID));
            Parent = new NodeRef(node.Value.InstanceID);

            if (!Parent.HasValue)
                World.BaseHierarchy.Add(this);
        }

        public void Free()
        {
            World.RemoveNode(this);
        }

        public virtual void OnEnterWorld() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnExitWorld() { }

        public static implicit operator NodeRef(Node node) => new NodeRef(node);
    }
}