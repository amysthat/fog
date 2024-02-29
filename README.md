# fog
fog, at its core is mainly a 2D game engine (or framework?) powered by the [MonoGame Framework](https://github.com/MonoGame/MonoGame). However, fog wasn't built with it being one size fits all. Instead, it focuses heavily on:

# simplism.
This does not mean fog makes it easy to make games, hell no. Instead, fog strips you away from all your fancy tools that you would get in engines like Unity, Godot, and Unreal Engine. This makes it so that it is hard to implement complicated mechanics to your games. Therefore, it will limit how far your feature-creep can go, because it is either literally impossible, or really hard. Instead, simplistic and/or simple games should only be made with this engine. Don't go around thinking you can make a rpg with this.

> ### fog doesn't even have ui support. all it can do is render text.

# differentiator.
In fog, entities cannot have children. They only have components. You have no scenes. You manage scene handling by yourself, for more power.

# capabilities.
 - entities system
 - asset pipeline
 - text & texture rendering
 - input system
 - runtime user assembly loading
 - (wip) editor

## planned features.
 - a stronger input system
 - shader support
 - cross-platform support
 - particle support
 - physics support

### branch details.
The [`main`](https://github.com/amysthat/fog) branch will always have finished, ready to use code.
If you want to see what I'm working on currently, check the [`dev`](https://github.com/amysthat/fog/tree/dev) branch out.
> Well, that is currently not the case as I haven't released a build yet. The `main` branch currently doesn't have a proper build.
