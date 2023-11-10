# Univrse dev test

Hello, I'm Martí Mayoral, this is my front end test. Check out the [live demo](https://www.martimayo.com/demo/univrse/)!

# 🎬 Preview 🎬

![Zone Controller](Readme%20Images/preview.gif)

# 🔠 Basics 🔠

Controls

- WASD or Arrow keys to move
- SPACE to jump between zones
- X to spawn enemy
- Shift to sprint

Zones are represented by diferent colors, neighbour zones have the same color.

Visible enemies are represented by a red circle with eyes. Non-visible enemies are represented only by their eyes.

# ⬇️ Get started ⬇️

I have uploaded a build of the app in [my web page](https://www.martimayo.com/demo/univrse/) so you don't have it locally to test it.

Simply clone and open in unity hub.

Unity version: 2021.3.6f1

Then open the main scene in `/Scenes/MainScene`

# 🛠️ Features 🛠️

## Create zones

Zones are defined by 2D objects that have a Collider2D (from unity) and a ZoneController (own script).

![Layers](Readme%20Images/layers.png)

To add a neighbour simply add it to the list of neighbours

![Zone Controller](Readme%20Images/zone%20controller.png)

Zones are in charge to detect when a player or an enemy enters and notify them that they have.

## Adding enemies

There is a prefab of an enemy.

It has a movement controller script `EnemyMovementAI` that controlls the movement of that enemy. On awake it chooses a random value between the range set for each parameter to make them diferent and feel more alive. I used [this script](https://forum.unity.com/threads/inspector-2-variables-in-one-slider.253753/#post-8744343) to have nicer sliders for the ranges.

![Zone Controller](Readme%20Images/enemy%20ai.png)

They have a script `EnemyController` to controll when to change the visibility, and `EnemyVisibility` to actually change it. Following development standards.

## Player

There is a prefab for the player.

It has a movement controller `PlayerMovement` that controlls the movement of the player.

It also has a script `JumpBetweenZones` to change between zones. When developing it there was the option to just add the root object of all zones and jump between their children, but I prefered to have an array of zones for more flexibility (e.g. if you want to set only one jump zone for each group of neighbour zones)

Finally it has a simple script to kill enemies on collision.

# 🗂️ Project Srtucture 🗂️

```jsx
-assets/
---CustomAtributes/
---Editor/
---Prefabs/
---Resources/
---Scenes/
---Scripts/
---TextMesh Pro/
---WebGLTemplates/
```

# ✉️ Contact ✉️

If you have any doubt or suggestion let me know at marti.mayoral2@gmail.com

Thanks.