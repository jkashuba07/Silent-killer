# Silent Killer - Player Character Architecture

## Component Architecture

```
Player GameObject
├── Transform
├── SpriteRenderer (Player visual)
├── CapsuleCollider2D (Player collision)
├── Rigidbody2D (Physics)
├── Animator (Animation state machine)
├── PlayerController (Movement & Jumping)
├── PlayerHealth (Health & Regeneration)
├── PlayerCombat (Attack System)
└── PlayerAnimationController (Animation Bridge)
    │
    ├── Child: GroundCheck (Transform)
    │   └── Used by PlayerController to detect ground
    │
    └── Child: AttackPoint (Transform)
        └── Used by PlayerCombat to detect enemies in range
```

## Script Dependencies

```
PlayerController
├── Depends on: Rigidbody2D, PlayerAnimationController
├── Controls: Movement, Jumping, Character Flipping
└── Updates: Animation states (IsMoving, IsGrounded, Jump)

PlayerHealth
├── Depends on: GameObject.FindGameObjectsWithTag("Enemy")
├── Controls: Health management, Regeneration
└── Provides: Health data for UI

PlayerCombat
├── Depends on: PlayerAnimationController
├── Controls: Attack input, Damage dealing
└── Updates: Animation states (WeakAttack, StrongAttack)

PlayerAnimationController
├── Depends on: Animator
├── Controls: Animation parameter updates
└── Provides: Unified animation interface
```

## Data Flow

### Movement Flow
```
Input (WASD/Arrows)
    ↓
PlayerController.Update() - Get input
    ↓
PlayerController.FixedUpdate() - Apply physics
    ↓
PlayerAnimationController - Update animation
    ↓
Animator - Play animation
```

### Combat Flow
```
Input (Z/X or Mouse)
    ↓
PlayerCombat.Update() - Check cooldowns
    ↓
PlayerCombat.PerformAttack() - Trigger attack
    ↓
├── PlayerAnimationController - Play animation
└── Physics2D.OverlapCircleAll() - Detect enemies
    ↓
    EnemyHealth.TakeDamage() - Deal damage
```

### Health Regeneration Flow
```
Update Loop
    ↓
PlayerHealth.Update() - Check for enemies
    ↓
No enemies? → Start regen timer
    ↓
After delay → Regenerate health
    ↓
HealthBarUI.Update() - Update visual
```

## Key Features

### 1. Modular Design
Each script handles a specific responsibility:
- **PlayerController**: Only movement
- **PlayerHealth**: Only health management
- **PlayerCombat**: Only combat
- **PlayerAnimationController**: Only animation

### 2. Loose Coupling
Scripts communicate through:
- GetComponent<>() for optional components
- Public methods for data access
- Unity's built-in systems (Physics2D, Tags)

### 3. Inspector Configuration
All parameters are serialized fields:
- Easy to tweak without code changes
- Designer-friendly
- Clear organization with [Header] attributes

### 4. Performance Considerations
- Physics calculations in FixedUpdate()
- Input handling in Update()
- Efficient enemy detection using layers
- Minimal FindGameObjectsWithTag() calls

## Testing Setup

### Required Tags
- **Player**: Assigned to player GameObject
- **Enemy**: Assigned to all enemy GameObjects
- **Platform**: Assigned to ground objects

### Required Layers
- **Layer 8 (Ground)**: For platforms
- **Layer 9 (Player)**: For player character
- **Layer 10 (Enemy)**: For enemies

### Input Mapping
Defined in ProjectSettings/InputManager.asset:
- Horizontal: Left/Right, A/D
- Jump: Space
- WeakAttack: Z, Left Mouse
- StrongAttack: X, Right Mouse

## Extension Points

### Easy to Add
1. **New Attacks**: Add more attack methods to PlayerCombat
2. **Combos**: Track attack sequences in PlayerCombat
3. **Special Abilities**: New scripts following same pattern
4. **Status Effects**: Extend PlayerHealth
5. **Different Weapons**: Swap combat parameters

### Animation Integration
Replace placeholder animations:
1. Create sprite sheets
2. Create Animation Clips in Unity
3. Update PlayerAnimator.controller states
4. No code changes needed!

## File Structure

```
Assets/
├── Scripts/
│   ├── PlayerController.cs
│   ├── PlayerHealth.cs
│   ├── PlayerCombat.cs
│   ├── PlayerAnimationController.cs
│   ├── EnemyHealth.cs
│   └── HealthBarUI.cs
├── Prefabs/
│   ├── Player.prefab
│   └── Enemy.prefab
├── Scenes/
│   └── TestLevel.unity
└── PlayerAnimator.controller
```

## Next Steps for Development

1. **Art Integration**
   - Replace placeholder sprites
   - Create actual animations
   - Add particle effects

2. **Audio Integration**
   - Add sound effects for attacks
   - Add footstep sounds
   - Add jump/land sounds

3. **Enhanced Combat**
   - Implement combo system
   - Add special moves
   - Create different enemy types

4. **UI Enhancement**
   - Complete health bar UI
   - Add attack cooldown indicators
   - Create damage numbers

5. **Game Feel**
   - Add screen shake on attacks
   - Implement hit-stop/freeze frames
   - Add attack trails
