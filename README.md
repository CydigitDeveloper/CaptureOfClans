# Capture of Clans

A small strategy game made in **48 hours** for **Jamination 7** (2024).

**Play it:** [cydigit.itch.io/capture-of-clans](https://cydigit.itch.io/capture-of-clans)

- Game developer: Mahmocan Başar
- 3D artist: Muhammed Ali Tüfekçi

![Capture of Clans](https://img.itch.zone/aW1nLzE2MTI5ODgyLnBuZw==/315x250%23c/rIdRE7.png)

## The game

You have a limited army: 20 knights, 10 archers and 3 cannons. Pick a unit, drag it over the field and place it. Then the armies, the archer and cannon towers and the bases fight it out. If all your units are dead and you have nothing left to place, you lose.

## How it works

- `PlacementSystem` raycasts from the mouse to the ground, shows a preview of the selected unit and places it on right-click. It keeps track of how many of each unit you have left.
- `Knight`, `Archer` and `Cannon` handle unit behaviour. `Arrow`, `ArcherArrow`, `Bullet` and `CannonBullet` are the projectiles.
- `ArcherTower`, `CannonTower` and `Base` are the enemy side.
- `GameManager` checks for defeat. `UIManager` and `LookAtCanvas` handle the UI and the health bars that face the camera.

## Running it

1. Open the project with **Unity 2022.3.26f1** (URP).
2. Open `Assets/Scenes/MainMenu.unity` and press Play.
