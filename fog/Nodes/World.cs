using System;
using System.Collections.Generic;

namespace fog.Nodes
{
    public static class World
    {
        public static List<NodeRef> BaseHierarchy { get; private set; } = new();
        private static Dictionary<Guid, Node> Nodes { get; set; } = new();

        public static NodeRef AddNode<T>(NodeRef? parent = null) where T : Node
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            instance.InstanceID = Guid.NewGuid();
            Nodes.Add(instance.InstanceID, instance);

            if (parent is not null)
            {
                parent.Value.Get().AddChild(instance);
                Logging.Info(nameof(World), $"Added node {typeof(T).Name} to {parent.Value.InstanceID}.");
            }
            else
            {
                BaseHierarchy.Add(instance);
                Logging.Info(nameof(World), $"Added node {typeof(T).Name} to base hierarchy.");
            }

            return new NodeRef(instance);
        }

        public static void RemoveNode(NodeRef node)
        {
            node.Get().OnExitWorld();
            node.Get().Reparent(null);
            BaseHierarchy.Remove(node);
            Nodes.Remove(node.InstanceID);
        }

        #region Import & Export
        internal static SerializedNode ExportNode(NodeRef node)
        {
            return new SerializedNode(node);
        }

        internal static Node ImportNode(SerializedNode serializedNode, NodeRef? parent = null)
        {
            var importedNodes = new List<Node>();

            Node node = InternalImportNode(serializedNode, ref importedNodes, parent);

            foreach (var _node in importedNodes)
            {
                _node.OnEnterWorld();
            }

            Logging.Info(nameof(World), $"Imported {importedNodes.Count} nodes.");

            return node;
        }

        private static Node InternalImportNode(SerializedNode serializedNode, ref List<Node> importedNodes, NodeRef? parent)
        {
            var type = Type.GetType(serializedNode.Type);

            if (type is null)
                type = Assemblies.Player.GetType(serializedNode.Type);

            if (type is null)
            {
                throw new Exception("Invalid node type");
            }

            Node instance = Activator.CreateInstance(type) as Node;
            instance.InstanceID = serializedNode.InstanceId;

            if (parent is not null)
            {
                instance.Parent = new NodeRef(parent.Value.InstanceID);
                parent.Value.Get().Children.Add(instance);
            }

            foreach (var property in serializedNode.Properties)
            {
                type.GetProperty(property.Key).SetValue(instance, property.Value);
            }

            importedNodes.Add(instance);
            Nodes.Add(instance.InstanceID, instance);

            foreach (var child in serializedNode.Children)
            {
                _ = InternalImportNode(child, ref importedNodes, new NodeRef(instance.InstanceID));
            }

            return instance;
        }
        #endregion

        internal static Node GetNode(Guid instanceId)
        {
            if (Nodes.TryGetValue(instanceId, out Node node)) return node;

            throw new NodeRefNotFoundException(instanceId);
        }

        internal static void Update()
        {
            foreach (var node in Nodes.Values)
            {
                node.OnUpdate();
            }
        }

        internal static void Draw()
        {
            foreach (var node in Nodes.Values)
            {
                node.OnDraw();
            }
        }

        internal static void ClearAllNodes()
        {
            int count = 0;
            foreach (var node in Nodes.Values)
            {
                try
                {
                    RemoveNode(node);
                }
                catch(Exception ex)
                {
                    Logging.Error(nameof(World), $"Node {node.InstanceID} threw an error whilst clearing all nodes: {ex}");
                    if (BaseHierarchy.Contains(node)) BaseHierarchy.Remove(node);
                    if (Nodes.ContainsKey(node.InstanceID)) Nodes.Remove(node.InstanceID);
                }
                count++;
            }

            Logging.Info(nameof(World), $"Cleared all {count} nodes.");
        }
    }
}