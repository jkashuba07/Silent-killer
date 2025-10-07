# PlayerController Implementation Details

## Overview
The PlayerController script implements enhanced movement mechanics for a 2D platformer character with support for analog controller input and variable jump heights.

## Key Features

### 1. Analog Movement Speed
The movement system reads input from the Horizontal axis (controller left stick or keyboard), which provides values from -1 to 1:
- **Input magnitude determines speed**: The actual speed is calculated as `input * maxMoveSpeed`
- **Smooth acceleration**: Uses `Mathf.MoveTowards` to smoothly transition between speeds
- **Configurable parameters**:
  - `maxMoveSpeed`: Maximum movement speed (default: 10 units/sec)
  - `acceleration`: How quickly the player accelerates to target speed (default: 50)

**Example Behavior**:
- Joystick at 25% tilt → Player moves at 2.5 units/sec
- Joystick at 50% tilt → Player moves at 5.0 units/sec
- Joystick at 100% tilt → Player moves at 10.0 units/sec

### 2. Variable Jump Height
The jump system charges while the jump button is held, allowing for precise control:
- **Jump charge**: Accumulates while button is held, capped at maximum
- **Quick tap**: Minimum jump force (5 units) for short hops
- **Hold**: Accumulates up to maximum jump force (15 units)
- **Configurable parameters**:
  - `minJumpForce`: Minimum jump force for tap jumps (default: 5)
  - `maxJumpForce`: Maximum jump force for charged jumps (default: 15)
  - `jumpChargeRate`: How quickly jump charges (default: 20/sec)
  - `maxJumpChargeTime`: Maximum time to charge (default: 0.5 sec)

**Jump Behavior**:
1. Press jump button while grounded → Start charging
2. Hold button → Charge accumulates linearly
3. Release button OR reach max charge → Execute jump
4. Jump force = minJumpForce + currentCharge

### 3. Ground Detection
Uses Physics2D circle overlap to detect ground:
- **Ground check position**: Child transform positioned below player
- **Layer-based detection**: Only detects objects on the Ground layer (Layer 8)
- **Visual debugging**: Gizmos show ground check area in Scene view

## Input Configuration
The script uses Unity's Input Manager:
- **Horizontal axis**: Default keyboard (A/D, Left/Right arrows) and gamepad left stick X-axis
- **Jump button**: Default keyboard (Space) and gamepad South button (A on Xbox, X on PlayStation)

To support full analog input, ensure:
1. Input Manager has "Horizontal" axis configured for gamepad
2. Axis type is set to "Joystick Axis" not "Key or Mouse Button"
3. Sensitivity and Dead zones are properly configured

## Testing in Unity Editor

### Setup
1. Open TestScene.unity
2. Ensure the Player GameObject has:
   - PlayerController component
   - Rigidbody2D (automatically added)
   - SpriteRenderer (for visualization)
   - GroundCheck child object positioned below player

### Manual Testing
1. **Keyboard testing**:
   - Press A/D or arrow keys to move
   - Partial movement not available with keyboard (digital input)
   - Press Space to jump

2. **Controller testing** (requires gamepad):
   - Gently tilt left stick for slow walk
   - Fully tilt left stick for sprint
   - Tap A button for short hop
   - Hold A button for high jump

3. **Observations**:
   - Watch player speed in Inspector (velocity values)
   - Try different tilt amounts to see speed variation
   - Try different jump button hold durations

### Unit Testing
Run the PlayerControllerTests to verify:
- Component initialization
- Public API methods work correctly
- Configuration values are accessible

Note: Full physics simulation testing requires Unity Test Runner with PlayMode tests.

## Customization

### Adjusting Movement Feel
- Increase `maxMoveSpeed` for faster movement
- Increase `acceleration` for snappier response
- Decrease `acceleration` for floatier, momentum-based feel

### Adjusting Jump Feel
- Increase `minJumpForce` for higher minimum jumps
- Increase `maxJumpForce` for higher maximum jumps
- Increase `jumpChargeRate` for faster charging
- Increase `maxJumpChargeTime` to allow longer charge windows

### Ground Detection
- Adjust `groundCheckRadius` to change detection area
- Move `groundCheck` transform up/down to adjust when jump is allowed
- Change `groundLayer` to detect different types of surfaces

## Known Limitations
1. Keyboard input is digital (on/off) and doesn't support analog movement
2. Air control is not currently implemented
3. No coyote time or jump buffering (common platformer features)
4. Ground detection is simple circle overlap (no slope handling)

## Future Enhancements
Possible additions:
- Air movement control
- Coyote time (grace period after leaving ground)
- Jump buffering (jump input queuing)
- Slope detection and handling
- Animation integration
- Particle effects for movement/jumping
