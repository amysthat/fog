namespace fog.Assets
{
    public struct AssetRef
    {
        public string Name { get; set; }

        public AssetRef() { Name = null; }
        public AssetRef(string name) { Name = name; }

        public object Get() => AssetPipeline.GetAsset(Name);
        public T Get<T>() => (T)AssetPipeline.GetAsset(Name);
        public bool IsPointing() => Name != string.Empty && Name != null;

        public static AssetRef FromAsset(object asset)
        {
            string value = AssetPipeline.GetName(asset);

            if (value == null)
            {
                throw new AssetNameNotFoundException();
            }

            return new AssetRef(value);
        }

        public static AssetRef Empty => new AssetRef(string.Empty);
    }
}