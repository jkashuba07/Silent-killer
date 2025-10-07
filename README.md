# Silent Killer

A Unity 2D action platformer featuring a dual-sword wielding warrior.

## 🎮 Features

### Player Character
- **Dual Sword Combat System**
  - Weak Attack (Z or Left Mouse): Fast, low damage
  - Strong Attack (X or Right Mouse): Slower, high damage
- **Regenerating Health System**
  - Health regenerates when no enemies are present
- **Smooth Platformer Movement**
  - Left/Right movement (Arrow Keys or WASD)
  - Jumping (Space)
- **Animation System**
  - Idle, Running, Jumping, Weak Attack, Strong Attack

## 📁 Folder Structure
- **Assets/Scripts**: All C# scripts for gameplay
- **Assets/Sprites**: Sprite images (placeholder sprites currently used)
- **Assets/Prefabs**: Reusable game objects (Player, Enemy)
- **Assets/Scenes**: Game scenes (TestLevel.unity)
- **ProjectSettings**: Unity project configuration
- **Packages**: Unity package dependencies

## 🚀 Getting Started

### Prerequisites
- Unity 2021.3.0f1 or later
- Basic understanding of Unity Editor

### Opening the Project
1. Clone this repository
2. Open Unity Hub
3. Click "Add" and select the project folder
4. Open the project with Unity 2021.3 or later

### Testing the Player Character
1. Open `Assets/Scenes/TestLevel.unity`
2. Press the Play button in Unity Editor
3. Use the controls listed below

### Controls
| Action | Primary | Alternative |
|--------|---------|-------------|
| Move Left | A or ← | |
| Move Right | D or → | |
| Jump | Space | |
| Weak Attack | Z | Left Mouse |
| Strong Attack | X | Right Mouse |

## 📖 Documentation

- **[PLAYER_CHARACTER.md](PLAYER_CHARACTER.md)**: Detailed player character documentation
- **[ARCHITECTURE.md](ARCHITECTURE.md)**: System architecture and design patterns

## 🎯 Current Implementation

### ✅ Completed
- Player movement and jumping mechanics
- Dual sword attack system (weak and strong)
- Health regeneration system
- Basic test level with platforms
- Animation controller (placeholder animations)
- Enemy prefab for combat testing

### 🔄 Placeholder Elements
- Sprite animations (using Unity's default sprites)
- Sound effects
- Visual effects

## 🛠️ Customization

All player parameters can be adjusted in the Unity Inspector:
- Movement speed
- Jump force
- Attack damage and cooldowns
- Health regeneration rate
- Attack ranges

## 📝 Scripts Overview

- **PlayerController.cs**: Handles movement and jumping
- **PlayerHealth.cs**: Manages health and regeneration
- **PlayerCombat.cs**: Handles attack input and damage
- **PlayerAnimationController.cs**: Controls animations
- **EnemyHealth.cs**: Simple enemy health system
- **HealthBarUI.cs**: UI for displaying player health

## 🎨 Next Steps

1. Replace placeholder sprites with actual artwork
2. Create proper animations for all player states
3. Add sound effects and music
4. Implement enemy AI
5. Create additional levels
6. Add UI menus and HUD

## 🤝 Contributing

This is a project template. Feel free to customize and extend it for your own game!

## 📄 License

This project is open source and available for use and modification.
