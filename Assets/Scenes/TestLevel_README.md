# Test Level Documentation

## Overview
The TestLevel scene is a basic testing environment for the Silent Killer game. It provides a simple platform for testing player movement, jumping, and attacks in a night-themed environment.

## Scene Components

### 1. Main Camera
- **Position**: (0, 0, -10)
- **Type**: Orthographic (for 2D gameplay)
- **Background Color**: Dark blue (#0a0e27) to match the night theme

### 2. Background
- **Type**: Sprite Renderer
- **Sprite**: NightSkyBackground.png (1920x1080)
- **Position**: (0, 0, 5) - Behind other game objects
- **Scale**: (20, 12, 1) - Scaled to cover the visible area
- **Sorting Layer**: Background
- **Description**: A night sky with stars, providing atmospheric theming

### 3. Ground Platform
- **Type**: Sprite Renderer with BoxCollider2D
- **Position**: (0, -3, 0)
- **Scale**: (30, 1, 1) - Wide platform for movement testing
- **Layer**: Ground (Layer 8)
- **Sorting Layer**: Ground
- **Color**: Dark green (#33664d)
- **Description**: A flat platform that the player can walk, jump, and land on

### 4. Directional Light
- **Type**: Directional Light
- **Position**: (0, 3, 0)
- **Rotation**: (50, -30, 0)
- **Color**: Blue-tinted (#4d4d80)
- **Intensity**: 0.3 (dim for night atmosphere)
- **Description**: Provides subtle ambient lighting for the night environment

## Ambient Lighting
- **Mode**: Ambient Color
- **Color**: Dark blue (#26264d)
- **Intensity**: 0.5
- **Description**: Simulates a night environment with low ambient light

## Testing Features
The test level is designed to support:
- **Movement**: Large ground platform (30 units wide) for horizontal movement
- **Jumping**: Platform is positioned to allow jump testing
- **Attacks**: Open space for attack animations and hitbox testing
- **Visual Theme**: Night sky background with atmospheric lighting

## Layer Configuration
- **Layer 8**: Ground (for platforms and ground objects)
- **Layer 9**: Player (for player character)

## Sorting Layers
1. **Background** (ID: 1) - For background sprites
2. **Ground** (ID: 2) - For platform and ground sprites
3. **Player** (ID: 3) - For player character sprites

## Notes
- The scene uses Unity's built-in sprite renderer and collider components
- The ground uses a Unity default square sprite (white square) with a color tint
- The background uses a custom night sky sprite with procedurally generated stars
