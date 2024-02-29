using FontStashSharp;
using System.Text.Json.Serialization;

namespace fog.Assets
{
    public class Font : Asset
    {
        [JsonIgnore] internal FontSystem? FontSystem { get; private set; }

        internal SpriteFontBase GetSize(float size) => FontSystem!.GetFont(size);

        public override void Load(byte[] data)
        {
            FontSystem = new FontSystem();
            FontSystem.AddFont(data);
        }
    }
}