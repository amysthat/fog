using fog;
using fog.Assets;
using fog.BuiltinComponents;
using fog.Entities;

namespace Game;

public static class Invocation
{
    [InvokeOnLoad(InvocationTime.BeforeStartupEntityLoad)]
    public static void InstantiateEntities()
    {
        Logging.Log("Adding test entity...");
        var entity = World.Add("Test");
        var spriteComponent = entity.AddComponent<SpriteComponent>();
        spriteComponent.Sprite = new AssetRef("idle");
        spriteComponent.Scale = .4f;
        entity.AddComponent<TestComponent>();
        Logging.Log("Added test entity.");
    }
}