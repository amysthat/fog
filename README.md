# fog
fog is mainly a 2D game engine powered by the [MonoGame Framework](https://github.com/MonoGame/MonoGame). fog grew out of the frustration of a Unity user switching to Godot. I love C#, and I know Godot supports C#. However, I don't find it as useful as Unity's C#.

# Capabilities
fog currently provides:
 - Node system
 - Asset pipeline & Serialization
 - Text & texture rendering
 - An input system
 - Runtime user assembly loading

## Planned Features
 - Sprite support
 - A more powerful input system
 - Editor*
 - Shader support
 - Cross-platform support*
 - Particle support
 - Collision support
 - Headless Mode*

> I'm currently considering from switching from MonoGame to OpenTK. However, I want to implement the ones without the asteriks before commiting into such acts. The reason I'm considering is because of the Editor, as I have currently no idea how to implement it using MonoGame.
> > Well, this will also require ImGuiNET it seems. We'll cross that bridge once we get to it.

#### Considered Features for Much, Much Later
 - 2D lighting support

### Branch Details
The [`main`](https://github.com/amysthat/fog) branch will always have finished, ready to use code.
If you want to see what I'm working on currently, check the [`dev`](https://github.com/amysthat/fog/tree/dev) branch out.
> Well, that is currently not the case as I haven't released a build yet. The `main` branch currently doesn't have a proper build.
