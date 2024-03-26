using fog.Memory;

namespace fog.Assets
{
    public abstract class Asset : Object
    {
        public abstract void Load(byte[] data);
    }
}
