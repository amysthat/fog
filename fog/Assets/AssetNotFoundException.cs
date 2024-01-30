using System;

namespace fog.Assets
{
    internal class AssetNotFoundException : Exception
    {
        public AssetNotFoundException(string assetName) : base($"{assetName} wasn't found.") { }
    }
}