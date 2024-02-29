using System.Text;

namespace fog.Assets
{
    /// <summary>
    /// Standard text file, imported with UTF-8
    /// </summary>
    public class TxtFile : Asset
    {
        public string Text { get; private set; } = string.Empty;

        public override void Load(byte[] data)
        {
            Text = Encoding.UTF8.GetString(data);
        }
    }
}