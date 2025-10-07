# Quick Setup Guide

## Opening the Project
1. Open Unity Hub
2. Click "Open" and select the `/Silent-killer` directory
3. Unity will import the project (may take a few minutes)

## Testing the Player Controller

### In the Unity Editor
1. Open `Assets/Scenes/TestScene.unity`
2. Click the Play button (▶) at the top of the editor
3. The scene contains:
   - **Player** (white square) positioned at (0, 1, 0)
   - **Ground** (invisible collider) positioned at (0, -2, 0)

### Controls
| Input | Keyboard | Gamepad |
|-------|----------|---------|
| Move Left | A or Left Arrow | Left Stick ← |
| Move Right | D or Right Arrow | Left Stick → |
| Jump | Space | A Button (Xbox) / X Button (PS) |

### Testing Analog Movement
**With Keyboard**: Movement is digital (on/off), so you'll always move at max speed.

**With Gamepad**:
1. Gently tilt the left stick → Player walks slowly
2. Push stick halfway → Player moves at half speed
3. Push stick fully → Player sprints at max speed

**Visual Verification**:
- Select the Player object in Hierarchy
- Watch the Rigidbody2D velocity values in the Inspector
- Velocity X should vary based on stick tilt amount

### Testing Variable Jump Height
**Quick Tap**:
1. Stand on the ground
2. Quickly tap the jump button
3. Player performs a short hop

**Hold Jump**:
1. Stand on the ground
2. Press and hold the jump button
3. Release after ~0.25 seconds
4. Player jumps to medium height

**Maximum Jump**:
1. Stand on the ground
2. Press and hold jump button
3. Hold for 0.5 seconds (or until auto-jump triggers)
4. Player jumps to maximum height

**Visual Verification**:
- Watch how high the player goes relative to the ground
- Quick taps should be noticeably shorter than held jumps

## Adjusting Parameters
1. Select the Player object in the Hierarchy
2. In the Inspector, find the PlayerController component
3. Adjust values and test:
   - **Max Move Speed**: Higher = faster movement
   - **Acceleration**: Higher = more responsive
   - **Min Jump Force**: Minimum jump height
   - **Max Jump Force**: Maximum jump height
   - **Jump Charge Rate**: How fast jump charges
   - **Max Jump Charge Time**: Maximum charge duration

## Troubleshooting

### Player doesn't move
- Check that the scene is playing (Play button is highlighted)
- Verify Input Manager has "Horizontal" axis configured
- For gamepad, ensure controller is connected before starting play mode

### Jump doesn't work
- Verify player is touching the ground
- Check that Ground object is on Layer 8
- Ensure Input Manager has "Jump" button configured

### Analog movement not working
- Must use a gamepad/controller (keyboard is digital only)
- Verify Input Manager "Horizontal" axis uses "Joystick Axis" type
- Check controller is properly connected and recognized by OS

## Running Unit Tests
1. Open Window > General > Test Runner
2. Select "PlayMode" or "EditMode" tab
3. Click "Run All" to execute tests
4. Tests verify basic functionality and API

## Scene Structure
```
TestScene
├── Main Camera (rendering the scene)
├── Ground (BoxCollider2D on Layer 8)
└── Player
    ├── PlayerController (movement script)
    ├── Rigidbody2D (physics)
    ├── SpriteRenderer (visual)
    └── GroundCheck (transform for ground detection)
```

## Next Steps
- Integrate with animation system
- Add visual feedback for movement states
- Create additional test levels
- Add sound effects for movement and jumping
