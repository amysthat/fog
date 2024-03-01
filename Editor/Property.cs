using fog.Assets;

namespace Editor
{
    public record Property
    {
        public Asset? Asset { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public Type? AssetType { get; set; }
        public Type? PropertyType { get; set; }

        public object GetValue() => AssetType!.GetProperty(PropertyName)!.GetValue(Asset)!;
        public void SetValue(object value) => AssetType!.GetProperty(PropertyName)!.SetValue(Asset, value);

        public static Property FromAsset(Asset asset, string name)
        {
            return new Property
            {
                Asset = asset,
                PropertyName = name,
                AssetType = asset.GetType(),
                PropertyType = asset.GetType().GetProperty(name)!.PropertyType,
            };
        }

        public static List<Property> GetAllProperties(Asset asset)
        {
            var type = asset.GetType();
            var properties = type.GetProperties();
            var list = new List<Property>();

            foreach (var property in properties)
            {
                list.Add(FromAsset(asset, property.Name));
            }

            return list;
        }
    }
}
