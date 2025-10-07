# Quick Reference Card

## 🎮 Player Controls
```
Movement:  A/D or ←/→
Jump:      Space
Attack 1:  Z or Left Mouse  (Weak - 10 dmg, 0.3s cd)
Attack 2:  X or Right Mouse (Strong - 25 dmg, 0.8s cd)
```

## 📁 Key Files
```
Scripts:    Assets/Scripts/Player*.cs
Prefabs:    Assets/Prefabs/Player.prefab
Test Scene: Assets/Scenes/TestLevel.unity
Docs:       README.md, SETUP_GUIDE.md
```

## 🔧 Quick Setup
```bash
1. Open Unity Hub
2. Add project from disk
3. Select Silent-killer folder
4. Open with Unity 2021.3+
5. Load TestLevel.unity
6. Press Play ▶
```

## ⚙️ Component Overview
```
PlayerController         → Movement & jumping
PlayerHealth            → Health & regeneration  
PlayerCombat            → Attack system
PlayerAnimationController → Animation bridge
```

## 🏷️ Tags & Layers
```
Tags:   Player, Enemy, Platform
Layers: Ground(8), Player(9), Enemy(10)
```

## 🎯 Default Values
```
Health:      100 HP
Regen:       5 HP/sec (no enemies)
Move Speed:  5 units/sec
Jump Force:  10 units
```

## 🔍 Common Tasks

### Add Player to New Scene
```
1. Drag Assets/Prefabs/Player.prefab to scene
2. Position at (0, 0, 0) or above ground
3. Add platforms with "Ground" layer
```

### Create New Platform
```
1. GameObject → 2D Object → Sprite → Square
2. Add BoxCollider2D
3. Set layer to "Ground" (Layer 8)
4. Add tag "Platform"
```

### Create New Enemy
```
1. Drag Assets/Prefabs/Enemy.prefab to scene
2. Position near player
3. Set tag to "Enemy"
4. Set layer to "Enemy" (Layer 10)
```

### Adjust Player Stats
```
1. Select Player in Hierarchy
2. View Inspector
3. Modify values in components
4. Changes apply immediately in Play mode
```

## 🐛 Debug Tools

### View Attack Ranges
```
1. Select Player in Hierarchy
2. Yellow circle = Weak attack range
3. Red circle = Strong attack range
```

### View Ground Check
```
1. Select Player in Hierarchy  
2. Red wireframe sphere at feet
3. Shows ground detection area
```

### Monitor Health
```
1. Enter Play mode
2. Select Player in Hierarchy
3. PlayerHealth → Current Health
4. Updates in real-time
```

## 🚀 Performance Tips
```
✓ Use layers for collision filtering
✓ Keep enemy count reasonable
✓ Disable unused components
✓ Use object pooling for many enemies
```

## 📝 Code Snippets

### Damage Player
```csharp
player.GetComponent<PlayerHealth>().TakeDamage(10f);
```

### Get Player Health
```csharp
float health = player.GetComponent<PlayerHealth>().GetCurrentHealth();
```

### Check If Player Facing Right
```csharp
bool facingRight = player.GetComponent<PlayerController>().IsFacingRight();
```

## 🎨 Customization Hotspots

### Change Player Color
```
Player → Sprite Renderer → Color
```

### Change Movement Feel
```
Player → PlayerController → Move Speed, Jump Force
Player → Rigidbody2D → Gravity Scale
```

### Change Combat Balance
```
Player → PlayerCombat → Attack values
```

### Change Health Behavior  
```
Player → PlayerHealth → Regen values
```

## 📚 Documentation Map
```
README.md              → Project overview
SETUP_GUIDE.md         → First-time setup
PLAYER_CHARACTER.md    → Character details
ARCHITECTURE.md        → Technical design
IMPLEMENTATION_SUMMARY.md → What's built
TESTING_CHECKLIST.md   → QA checklist
```

## 🔗 File Relationships
```
Player.prefab
  ├─ Uses: All Player*.cs scripts
  └─ Children: GroundCheck, AttackPoint

TestLevel.unity
  ├─ Contains: Player instance
  └─ Contains: Platforms

PlayerAnimator.controller
  └─ Used by: Player.prefab → Animator
```

## ⚡ Shortcuts
```
Play/Stop:     Ctrl/Cmd + P
Pause:         Ctrl/Cmd + Shift + P
Frame Advance: Ctrl/Cmd + Alt + P
Select All:    Ctrl/Cmd + A
Duplicate:     Ctrl/Cmd + D
Focus:         F key (with object selected)
```

## 🎯 Next Steps
```
1. Replace placeholder sprites
2. Create animation clips
3. Add sound effects
4. Build enemy AI
5. Design levels
6. Implement UI
```

---

**Project Status**: ✅ Core features complete
**Version**: 1.0.0
**Unity**: 2021.3.0f1+
**Last Updated**: 2024
