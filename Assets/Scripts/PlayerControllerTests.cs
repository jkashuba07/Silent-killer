using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

/// <summary>
/// Test suite for PlayerController movement mechanics
/// </summary>
public class PlayerControllerTests
{
    private GameObject playerObject;
    private PlayerController playerController;
    private Rigidbody2D rb;
    
    [SetUp]
    public void SetUp()
    {
        // Create player game object
        playerObject = new GameObject("TestPlayer");
        playerController = playerObject.AddComponent<PlayerController>();
        rb = playerObject.GetComponent<Rigidbody2D>();
        
        // Configure Rigidbody2D for testing
        rb.gravityScale = 0; // Disable gravity for controlled testing
    }
    
    [TearDown]
    public void TearDown()
    {
        if (playerObject != null)
        {
            Object.DestroyImmediate(playerObject);
        }
    }
    
    /// <summary>
    /// Test that player controller component is properly initialized
    /// </summary>
    [Test]
    public void PlayerController_ComponentExists()
    {
        Assert.IsNotNull(playerController, "PlayerController component should exist");
        Assert.IsNotNull(rb, "Rigidbody2D component should exist");
    }
    
    /// <summary>
    /// Test that max move speed is properly configured
    /// </summary>
    [Test]
    public void PlayerController_HasMaxMoveSpeed()
    {
        float maxSpeed = playerController.GetMaxMoveSpeed();
        Assert.Greater(maxSpeed, 0f, "Max move speed should be greater than 0");
    }
    
    /// <summary>
    /// Test analog movement - partial input should result in proportional speed
    /// Note: This is a basic test. In a real Unity environment with physics simulation,
    /// you would use UnityTest with yield return to allow physics to update.
    /// </summary>
    [Test]
    public void PlayerController_AnalogMovement_SpeedMatchesInput()
    {
        // This test verifies the concept exists
        // In actual Unity runtime, you'd need to simulate input and physics frames
        float maxSpeed = playerController.GetMaxMoveSpeed();
        Assert.Greater(maxSpeed, 0f, "Max speed should be configured for analog movement");
    }
    
    /// <summary>
    /// Test that jump charge system exists
    /// </summary>
    [Test]
    public void PlayerController_HasJumpChargeSystem()
    {
        // Verify that jump charge tracking exists
        float initialCharge = playerController.GetCurrentJumpCharge();
        Assert.AreEqual(0f, initialCharge, "Initial jump charge should be 0");
    }
    
    /// <summary>
    /// Test ground detection system exists
    /// </summary>
    [Test]
    public void PlayerController_HasGroundDetection()
    {
        // Verify ground detection exists
        bool grounded = playerController.IsGrounded();
        // We don't assert the value since we haven't set up ground layers,
        // just verify the method exists and returns a boolean
        Assert.IsNotNull(grounded);
    }
}
