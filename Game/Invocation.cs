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
        return;
        Logging.Log("Adding test entity...");

        var entity = World.Add("Test");

        var spriteComponent = entity.Get()
            .AddComponent<SpriteComponent>();
        spriteComponent.Sprite = new AssetRef("idle");
        spriteComponent.Scale = .4f;

        entity.Get().AddComponent<TestComponent>();

        Logging.Log("Added test entity.");

        Logging.Log("spriteComponent serialization:");
        Logging.Log(AssetPipeline.Serialization.SerializeContent(spriteComponent));
        Logging.Log("entity serialization:");
        Logging.Log(AssetPipeline.Serialization.SerializeContent(entity.Get()));
    }
}