# Silent Killer

This is a Unity 2D project template for the Silent Killer game.

## Folder Structure
- **Scripts**: Contains all C# scripts.
- **Sprites**: Contains all sprite images.
- **Prefabs**: Contains all prefab objects.
- **Scenes**: Contains all scene files.

## Getting Started
1. Open the project in Unity 2022.3.0f1 or later.
2. The TestScene contains a configured player with enhanced movement mechanics.

## Player Movement Features

### Analog Movement Speed
- The player's movement speed matches the degree of left joystick tilt on a controller
- Slight tilt = slow walk, full tilt = sprint
- Smooth acceleration and deceleration for responsive feel
- Maximum speed: 10 units/second (configurable)

### Variable Jump Height
- Jump height depends on how long the jump button is held
- Quick tap = short hop (minimum jump force: 5)
- Hold button = higher jump (maximum jump force: 15)
- Maximum charge time: 0.5 seconds
- Auto-jump when max charge is reached

## Testing
- Open TestScene in the Unity Editor
- Use WASD/Arrow keys or gamepad left stick to move
- Press Space or gamepad A button to jump
- Test partial joystick inputs for analog movement
- Test quick tap vs. hold for variable jump heights
