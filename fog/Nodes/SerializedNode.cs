using System;
using System.Collections.Generic;
using System.Reflection;

namespace fog.Nodes
{
    public class SerializedNode
    {
        public string Type { get; set; }
        public Guid InstanceId { get; set; }

        public List<SerializedNode> Children { get; private set; }
        public Dictionary<string, object> Properties { get; set; }

        public SerializedNode() { }

        public SerializedNode(Node from)
        {
            Type type = from.GetType();
            Type = type.FullName;
            InstanceId = from.InstanceID;

            Children = new();
            Properties = new();

            foreach (var property in type.GetProperties())
            {
                if (property.MemberType != MemberTypes.Field && property.MemberType != MemberTypes.Property)
                    continue;

                if (property.Name == "Children" || property.Name == "InstanceID" || property.Name == "Parent")
                    continue;

                var value = property.GetValue(from);
                Properties.Add(property.Name, value);
            }

            foreach (var child in from.Children)
            {
                Children.Add(new SerializedNode(child));
            }
        }
    }
}