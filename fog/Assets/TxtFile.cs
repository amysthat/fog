using fog.Memory;
using System.Text;

namespace fog.Assets
{
    /// <summary>
    /// Standard text file, imported with UTF-8
    /// </summary>
    public class TxtFile : Object
    {
        public string text { get; set; }

        public static TxtFile FromBytes(byte[] content)
        {
            var txtFile = MemoryManager.Allocate<TxtFile>();
            txtFile.text = Encoding.UTF8.GetString(content);

            return txtFile;
        }
    }
}