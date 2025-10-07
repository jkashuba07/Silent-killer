# Silent Killer - Player Character Documentation

## Overview
The player character for Silent Killer is a dual-sword wielding warrior with regenerating health and smooth platformer controls.

## Features

### 1. Movement System
- **Horizontal Movement**: Use Left/Right arrow keys or A/D keys
- **Jumping**: Press Space to jump
- **Speed**: Configurable movement speed (default: 5 units/sec)
- **Jump Force**: Configurable jump force (default: 10 units)

### 2. Combat System

#### Weak Attack
- **Input**: Z key or Left Mouse Button
- **Damage**: 10 (configurable)
- **Cooldown**: 0.3 seconds
- **Range**: 1.5 units
- **Description**: Fast attack with low damage

#### Strong Attack
- **Input**: X key or Right Mouse Button
- **Damage**: 25 (configurable)
- **Cooldown**: 0.8 seconds
- **Range**: 2 units
- **Description**: Slower attack with higher damage

### 3. Health System
- **Max Health**: 100 (configurable)
- **Health Regeneration**: 5 HP per second (configurable)
- **Regeneration Trigger**: Health regenerates when no enemies with "Enemy" tag are present
- **Regeneration Delay**: 2 seconds after last damage (configurable)

### 4. Animation System
The player has placeholder animations for:
- Idle
- Running
- Jumping
- Weak Attack
- Strong Attack

Animations are triggered automatically based on player actions.

## Scripts

### PlayerController.cs
Handles movement, jumping, and character flipping.

**Configurable Parameters:**
- Move Speed
- Jump Force
- Ground Check Radius
- Ground Layer Mask

### PlayerHealth.cs
Manages player health and regeneration.

**Configurable Parameters:**
- Max Health
- Health Regeneration Rate
- Regeneration Delay

### PlayerCombat.cs
Handles attack input and damage dealing.

**Configurable Parameters:**
- Weak Attack Damage
- Weak Attack Cooldown
- Weak Attack Range
- Strong Attack Damage
- Strong Attack Cooldown
- Strong Attack Range
- Enemy Layers

### PlayerAnimationController.cs
Bridges between gameplay scripts and the Animator component.

### EnemyHealth.cs
Simple enemy health system for testing combat.

### HealthBarUI.cs
Displays player health as a UI bar (requires UI setup).

## Test Scene

The TestLevel scene includes:
- Main Camera (orthographic, size 5)
- Ground platform (20x1 units at y=-4)
- Platform 1 (4x1 units at x=-5, y=-1)
- Platform 2 (4x1 units at x=5, y=-1)

## Setup Instructions

1. **Add Player to Scene**:
   - Drag the Player prefab from Assets/Prefabs into your scene
   - Position at (0, 0, 0) or desired starting position

2. **Configure Layers**:
   - Ensure "Ground" layer (Layer 8) is assigned to all platforms
   - Ensure "Player" layer (Layer 9) is assigned to player
   - Ensure "Enemy" layer (Layer 10) is assigned to enemies

3. **Test the Character**:
   - Open Assets/Scenes/TestLevel.unity
   - Press Play
   - Use arrow keys or WASD to move
   - Press Space to jump
   - Press Z for weak attacks
   - Press X for strong attacks

## Controls Summary

| Action | Primary Key | Alternative Key |
|--------|-------------|-----------------|
| Move Left | Left Arrow | A |
| Move Right | Right Arrow | D |
| Jump | Space | - |
| Weak Attack | Z | Left Mouse Button |
| Strong Attack | X | Right Mouse Button |

## Future Improvements

- Add actual sprite animations instead of placeholders
- Implement attack combos
- Add sound effects for attacks and movement
- Implement dash ability
- Add particle effects for attacks
- Create enemy AI for combat testing
