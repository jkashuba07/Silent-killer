# Testing Checklist

Use this checklist to verify all features are working correctly in Unity.

## 🎮 Pre-Test Setup

- [ ] Unity 2021.3 or later installed
- [ ] Project opened successfully
- [ ] No console errors on project load
- [ ] TestLevel.unity scene loaded
- [ ] Player visible in scene

## 🏃 Movement Tests

### Basic Movement
- [ ] Press A or Left Arrow → Player moves left
- [ ] Press D or Right Arrow → Player moves right
- [ ] Player sprite flips direction when changing movement direction
- [ ] Release movement keys → Player stops moving smoothly
- [ ] Movement speed feels responsive (adjust if needed)

### Jumping
- [ ] Press Space while on ground → Player jumps
- [ ] Press Space while in air → Nothing happens (no double jump)
- [ ] Player falls back down due to gravity
- [ ] Player can land on platforms
- [ ] Player can jump from platform to platform

### Ground Detection
- [ ] Player can stand on the main ground platform
- [ ] Player can stand on Platform1 (left)
- [ ] Player can stand on Platform2 (right)
- [ ] Player doesn't jump when falling
- [ ] Jump only works when touching ground

## ⚔️ Combat Tests

### Weak Attack
- [ ] Press Z → Weak attack triggers
- [ ] Press Left Mouse Button → Weak attack triggers
- [ ] Cannot spam attack (0.3s cooldown)
- [ ] Attack animation trigger works (check Animator)

### Strong Attack
- [ ] Press X → Strong attack triggers
- [ ] Press Right Mouse Button → Strong attack triggers
- [ ] Cannot spam attack (0.8s cooldown)
- [ ] Strong attack has longer cooldown than weak attack
- [ ] Attack animation trigger works (check Animator)

### Damage Dealing
- [ ] Drag Enemy prefab into scene
- [ ] Position enemy near player
- [ ] Weak attack damages enemy
- [ ] Strong attack damages enemy
- [ ] Strong attack deals more damage than weak attack
- [ ] Enemy dies after enough hits
- [ ] Enemy disappears when health reaches 0

### Attack Range
- [ ] Select Player in scene
- [ ] Look for yellow circle (weak attack range) in Scene view
- [ ] Look for red circle (strong attack range) in Scene view
- [ ] Strong attack range is larger than weak attack range
- [ ] Attacks only hit enemies within range

## ❤️ Health System Tests

### Health Regeneration
- [ ] Player starts with full health (100)
- [ ] Health visible in Inspector when selected
- [ ] With NO enemies in scene: Health regenerates
- [ ] Regeneration is gradual (not instant)
- [ ] Health stops at maximum (100)

### Regeneration with Enemies
- [ ] Add Enemy prefab to scene
- [ ] Health does NOT regenerate while enemy exists
- [ ] Kill the enemy
- [ ] Wait 2 seconds
- [ ] Health starts regenerating
- [ ] Health regeneration is smooth (5 HP/second)

### Taking Damage
To test (requires manual health modification in Inspector):
- [ ] Select Player during Play mode
- [ ] Modify currentHealth to 50
- [ ] Remove all enemies from scene
- [ ] Wait 2 seconds
- [ ] Health regenerates back to 100

## 🎨 Animation Tests

### Animation States
- [ ] Player Idle: When not moving
- [ ] Player Running: When moving left/right
- [ ] Player Jumping: When in air (trigger)
- [ ] Player Weak Attack: When attacking (trigger)
- [ ] Player Strong Attack: When attacking (trigger)

**Note**: These are placeholder animations, so visual changes may be minimal.

### Animator Window Check
- [ ] Open Window → Animation → Animator
- [ ] Select Player in scene
- [ ] Observe state machine while playing
- [ ] States transition correctly based on actions
- [ ] Parameters update correctly

## 🎯 Scene Tests

### Camera
- [ ] Camera shows entire play area
- [ ] Camera is orthographic (2D view)
- [ ] Player is centered in view
- [ ] All platforms are visible

### Platforms
- [ ] Ground platform is solid
- [ ] Platform1 is solid
- [ ] Platform2 is solid
- [ ] Player doesn't fall through platforms
- [ ] Player can walk off platform edges

### Physics
- [ ] Player falls when walking off platform
- [ ] Gravity pulls player down
- [ ] Player doesn't rotate when moving
- [ ] Player collision works properly

## 🔧 Inspector Configuration Tests

### PlayerController Component
- [ ] Move Speed field visible (default: 5)
- [ ] Jump Force field visible (default: 10)
- [ ] Ground Check reference assigned
- [ ] Ground Check Radius visible (default: 0.2)
- [ ] Ground Layer set to "Ground"

### PlayerHealth Component
- [ ] Max Health field visible (default: 100)
- [ ] Health Regen Rate visible (default: 5)
- [ ] Regen Delay visible (default: 2)
- [ ] Current Health updates in Play mode

### PlayerCombat Component
- [ ] Weak Attack Damage visible (default: 10)
- [ ] Weak Attack Cooldown visible (default: 0.3)
- [ ] Weak Attack Range visible (default: 1.5)
- [ ] Strong Attack Damage visible (default: 25)
- [ ] Strong Attack Cooldown visible (default: 0.8)
- [ ] Strong Attack Range visible (default: 2)
- [ ] Attack Point reference assigned
- [ ] Enemy Layers set to "Enemy"

### Rigidbody2D Component
- [ ] Body Type: Dynamic
- [ ] Mass: 1
- [ ] Gravity Scale: 3
- [ ] Constraints: Freeze Rotation Z enabled

## 🐛 Known Limitations

These are expected behaviors (not bugs):

- [ ] No visible attack animations (placeholders only)
- [ ] No sound effects
- [ ] No visual effects for attacks
- [ ] No damage numbers
- [ ] No health bar UI (script exists but not connected)
- [ ] Player uses simple geometric sprite
- [ ] Enemy uses simple geometric sprite

## ✅ Success Criteria

All core features should work:
- ✅ Movement is smooth and responsive
- ✅ Jumping works correctly
- ✅ Both attacks can be performed
- ✅ Enemies take damage and die
- ✅ Health regenerates when no enemies present
- ✅ All Inspector values are configurable

## 📊 Performance Check

- [ ] Game runs at 60 FPS (check Stats window)
- [ ] No console errors during play
- [ ] No console warnings during play
- [ ] Smooth gameplay with no stuttering
- [ ] Input is responsive

## 🎬 Final Test Scenario

Complete gameplay loop:
1. [ ] Start Play mode
2. [ ] Move left and right
3. [ ] Jump to Platform1
4. [ ] Jump to Platform2
5. [ ] Jump back to ground
6. [ ] Add Enemy prefab near player
7. [ ] Perform weak attacks until enemy dies
8. [ ] Add another enemy
9. [ ] Perform strong attacks until enemy dies
10. [ ] Wait for health to regenerate
11. [ ] Stop Play mode
12. [ ] No errors in console

## 🔄 Customization Tests

Try adjusting values:
- [ ] Increase Move Speed to 10 → Player moves faster
- [ ] Increase Jump Force to 15 → Player jumps higher
- [ ] Decrease Weak Attack Cooldown to 0.1 → Faster attacks
- [ ] Increase Strong Attack Damage to 50 → One-shot enemies
- [ ] Increase Health Regen Rate to 20 → Faster healing

All changes should work immediately in Play mode.

## 📝 Test Results

Record your results:

**Date Tested**: _______________
**Unity Version**: _______________
**Tester Name**: _______________

**Overall Status**: 
- [ ] All features working
- [ ] Some issues found (list below)
- [ ] Major issues found (list below)

**Issues Found**:
1. _______________
2. _______________
3. _______________

**Notes**:
_______________________________________________
_______________________________________________
_______________________________________________
