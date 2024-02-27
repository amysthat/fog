using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Text.Json.Serialization;

namespace fog.Assets
{
    public class Sprite : Asset
    {
        [JsonIgnore] internal Texture2D? Texture { get; private set; }

        public override void Load(byte[] data)
        {
            var memoryStream = new MemoryStream(data);

            var texture = Texture2D.FromStream(fogEngine.Instance.GraphicsDevice, memoryStream);
            memoryStream.Dispose();

            Texture = texture;

            Logging.Debug("Successfully loaded sprite.");
        }
    }
}