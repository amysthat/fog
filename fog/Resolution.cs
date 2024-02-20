using System.Text.Json.Serialization;

namespace fog
{
    public struct Resolution
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fullscreen { get; set; }

        [JsonIgnore] public readonly float AspectRatio => (float)Height / Width;
    }
}