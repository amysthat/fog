using System.Text;
using System.Text.Json.Serialization;

namespace fog.Assets
{
    /// <summary>
    /// Standard text file, imported with UTF-8
    /// </summary>
    public class TxtFile : Asset
    {
        [JsonIgnore] public string Text { get; private set; } = string.Empty;
        public string UselessData { get; set; } = "hi!";

        public override void Load(byte[] data)
        {
            Text = Encoding.UTF8.GetString(data);
        }
    }
}