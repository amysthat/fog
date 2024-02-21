using fog.Assets;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace fog.Entities;

[JsonConverter(typeof(ComponentList))]
public class ComponentListConverter : JsonConverter<ComponentList>
{
    public override ComponentList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var componentList = new ComponentList();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return componentList;
            }

            // Get the key.
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string typeName = reader.GetString();

            var type = Type.GetType(typeName);
            if (type == null)
                type = Assemblies.Player.GetType(typeName);

            if (type == null)
                throw new TypeLoadException($"Can not find type \"{typeName}\".");

            // Get the value.
            var componentData = reader.GetString();
            var component = JsonSerializer.Deserialize(componentData, type);

            // Add to dictionary.
            componentList.Types.Add(typeName);
            componentList.Components.Add((Component) component);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, ComponentList value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        for (int i = 0; i < value.Count; i++)
        {
            var typeName = value.Types[i];
            var component = value.Components[i];

            writer.WritePropertyName(typeName);

            var data = AssetPipeline.Serialization.SerializeContent(component);
            writer.WriteStringValue(data);
        }

        writer.WriteEndObject();
    }
}