using System.Text;

namespace fog.Assets
{
    /// <summary>
    /// Standard text file, imported with UTF-8
    /// </summary>
    public class TxtFile
    {
        public string text { get; set; }

        public static TxtFile FromBytes(byte[] content)
        {
            return new TxtFile
            {
                text = Encoding.UTF8.GetString(content),
            };
        }
    }
}