# Walking Simulator Base (Built On 2020.1.16f1)
Base files for walking sim games made in Unity; can make multiple projects based off of these.  Mostly for personal use but if anyone sees these and wants to make something based off of them go right ahead.

## Movement
movement is standard 3D forward-back-left-right FPS controller.  The camera, however, is locked to left and right motion.  This is a personal choice, and changing this is very simple if necessary.
Comes with animation and sound already made but can be changed.

## Interaction System
Credit to VeryHotShark (https://github.com/VeryHotShark/)

The interaction system is built around using `InteractableBase` and override it's onclick() function to make things happen. It's a pretty complex yet flexible system but simple to work with.

### `DestroyObject`
A very simple interaction that destroys the object interacted with.

### `DialogueController`
Credit to Zyger (https://www.youtube.com/watch?v=hvgfFNorZH8)

A simple dialogue controller stemming from the `InteractableBase`.  Very basic and currently only supports sentences, but dialogue box is fully animated with a base design.
Can be changed however the user wants.

## Ideas that weren't implemented now but may be implemented later
I had an idea for a default item system, but with how different items can work in some guys I opted out.  I may add a small default one later, 
but building something with `DestroyObject` function or from scratch may be a lot more simple.
