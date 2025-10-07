# Quick Setup Guide

## First Time Setup

### 1. Open the Project
1. Launch Unity Hub
2. Click "Add" → "Add project from disk"
3. Navigate to the Silent-killer folder
4. Click "Select Folder"
5. Open the project (Unity 2021.3 or later recommended)

### 2. Verify Tags
Unity should automatically create these tags, but verify in Edit → Project Settings → Tags and Layers:
- **Tags**: Player, Enemy, Platform
- **Layers**: 
  - Layer 8: Ground
  - Layer 9: Player
  - Layer 10: Enemy

### 3. Test the Game
1. In the Project window, navigate to `Assets/Scenes/`
2. Double-click `TestLevel.unity` to open it
3. Click the Play button (▶) at the top of the editor
4. Use the keyboard controls to test the player

### 4. Understanding the Scene

The TestLevel scene contains:
- **Main Camera**: Orthographic camera centered on the action
- **Ground**: Large platform at the bottom
- **Platform1 & Platform2**: Two floating platforms for jumping practice

**Note**: The Player prefab is NOT in the scene by default. You need to add it!

### 5. Add Player to Scene
1. In the Project window, navigate to `Assets/Prefabs/`
2. Drag the `Player.prefab` into the Scene or Hierarchy
3. Position it at approximately (0, 0, 0) or above a platform
4. Press Play to test

### 6. (Optional) Add Test Enemy
1. In the Project window, navigate to `Assets/Prefabs/`
2. Drag the `Enemy.prefab` into the Scene
3. Position it near the player (e.g., at (3, -2, 0))
4. Press Play and test combat
5. Notice: Health regeneration only works when all enemies are defeated

## Testing Checklist

- [ ] Player moves left and right (A/D or Arrow keys)
- [ ] Player jumps (Space)
- [ ] Player attacks with Z (weak attack)
- [ ] Player attacks with X (strong attack)
- [ ] Player sprite flips when changing direction
- [ ] Player can walk on platforms
- [ ] Player can jump between platforms
- [ ] Attacks damage enemies (add Enemy prefab to test)
- [ ] Health regenerates when no enemies present

## Common Issues

### Issue: Player falls through platforms
**Solution**: 
- Check that platforms have the "Ground" layer (Layer 8)
- Verify Player's groundCheck layer mask is set to "Ground"
- Ensure platforms have BoxCollider2D component

### Issue: Attacks don't damage enemies
**Solution**:
- Verify enemy has "Enemy" tag
- Check enemy has "Enemy" layer (Layer 10)
- Ensure PlayerCombat's enemyLayers includes Enemy layer
- Add EnemyHealth component to enemy

### Issue: Player won't jump
**Solution**:
- Ensure player has a GroundCheck child object
- Verify GroundCheck is positioned at player's feet
- Check groundCheckRadius is appropriate (default: 0.2)

### Issue: Animations not playing
**Solution**:
- Animations are placeholder - they won't show visible changes
- Check Animator component is attached
- Verify PlayerAnimator.controller is assigned

### Issue: Controls not responding
**Solution**:
- Verify InputManager.asset is in ProjectSettings
- Check Edit → Project Settings → Input Manager
- Ensure Horizontal, Jump, WeakAttack, and StrongAttack are configured

## Customization Tips

### Adjust Player Feel
1. Select Player prefab or instance
2. In Inspector, find PlayerController component
3. Modify:
   - Move Speed: Higher = faster movement
   - Jump Force: Higher = jumps higher
   - Ground Check Radius: Affects jump detection

### Tweak Combat
1. Select Player prefab or instance
2. In Inspector, find PlayerCombat component
3. Modify:
   - Weak Attack Damage
   - Strong Attack Damage
   - Attack Cooldowns
   - Attack Ranges

### Change Health System
1. Select Player prefab or instance
2. In Inspector, find PlayerHealth component
3. Modify:
   - Max Health
   - Health Regen Rate
   - Regen Delay

## Building for Testing

### Create a Build
1. File → Build Settings
2. Click "Add Open Scenes" to add TestLevel
3. Select your target platform (Windows, Mac, Linux)
4. Click "Build" and choose output folder
5. Run the executable to test outside Unity

## Next Steps

1. **Art**: Replace placeholder sprites with your own artwork
2. **Animation**: Create sprite animation clips
3. **Sound**: Add audio files and AudioSource components
4. **Levels**: Design additional scenes with more platforms and challenges
5. **Enemies**: Create enemy AI scripts
6. **UI**: Build proper health bars, menus, and HUD

## Need Help?

Check the documentation:
- [PLAYER_CHARACTER.md](PLAYER_CHARACTER.md) - Player character details
- [ARCHITECTURE.md](ARCHITECTURE.md) - System architecture

## Development Workflow

1. Make changes to scripts or prefabs
2. Test in Play mode
3. If satisfied, save the scene (Ctrl+S / Cmd+S)
4. Commit changes to version control

Remember: Changes made in Play mode are NOT saved!
