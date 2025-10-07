using UnityEngine;

/// <summary>
/// Player controller with analog movement and variable jump height
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float acceleration = 50f;
    
    [Header("Jump Settings")]
    [SerializeField] private float minJumpForce = 5f;
    [SerializeField] private float maxJumpForce = 15f;
    [SerializeField] private float jumpChargeRate = 20f;
    [SerializeField] private float maxJumpChargeTime = 0.5f;
    
    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    
    private Rigidbody2D rb;
    private float horizontalInput;
    private float currentJumpCharge;
    private bool isJumpButtonHeld;
    private bool isGrounded;
    private bool canJump;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        // Get horizontal input (analog stick value from -1 to 1)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Check if grounded
        CheckGrounded();
        
        // Handle jump input
        HandleJumpInput();
    }
    
    private void FixedUpdate()
    {
        // Apply analog movement
        ApplyMovement();
    }
    
    /// <summary>
    /// Apply movement based on analog input magnitude
    /// </summary>
    private void ApplyMovement()
    {
        // Calculate target velocity based on input magnitude
        // Input magnitude represents how far the joystick is tilted
        float targetVelocityX = horizontalInput * maxMoveSpeed;
        
        // Smoothly accelerate to target velocity
        float newVelocityX = Mathf.MoveTowards(
            rb.velocity.x, 
            targetVelocityX, 
            acceleration * Time.fixedDeltaTime
        );
        
        // Apply the new velocity while preserving vertical velocity
        rb.velocity = new Vector2(newVelocityX, rb.velocity.y);
    }
    
    /// <summary>
    /// Handle variable jump height based on button hold duration
    /// </summary>
    private void HandleJumpInput()
    {
        // Check if jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Start charging jump
            isJumpButtonHeld = true;
            currentJumpCharge = 0f;
            canJump = true;
        }
        
        // Charge jump while button is held
        if (Input.GetButton("Jump") && isJumpButtonHeld && canJump)
        {
            currentJumpCharge += jumpChargeRate * Time.deltaTime;
            currentJumpCharge = Mathf.Min(currentJumpCharge, maxJumpForce - minJumpForce);
            
            // Cap charge time
            if (currentJumpCharge >= (maxJumpForce - minJumpForce) || 
                (currentJumpCharge / jumpChargeRate) >= maxJumpChargeTime)
            {
                // Auto-jump if max charge reached
                PerformJump();
            }
        }
        
        // Execute jump when button is released
        if (Input.GetButtonUp("Jump") && isJumpButtonHeld && canJump)
        {
            PerformJump();
        }
    }
    
    /// <summary>
    /// Execute the jump with the current charge
    /// </summary>
    private void PerformJump()
    {
        if (!canJump) return;
        
        // Calculate jump force based on charge
        float jumpForce = minJumpForce + currentJumpCharge;
        
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        // Reset jump state
        isJumpButtonHeld = false;
        canJump = false;
        currentJumpCharge = 0f;
    }
    
    /// <summary>
    /// Check if player is touching the ground
    /// </summary>
    private void CheckGrounded()
    {
        // Use ground check position if available, otherwise use player position
        Vector2 checkPosition = groundCheck != null ? groundCheck.position : transform.position;
        
        // Check for ground collision
        isGrounded = Physics2D.OverlapCircle(checkPosition, groundCheckRadius, groundLayer);
    }
    
    /// <summary>
    /// Visualize ground check in editor
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
    
    // Public getters for testing
    public float GetCurrentSpeed()
    {
        return Mathf.Abs(rb.velocity.x);
    }
    
    public float GetMaxMoveSpeed()
    {
        return maxMoveSpeed;
    }
    
    public bool IsGrounded()
    {
        return isGrounded;
    }
    
    public float GetCurrentJumpCharge()
    {
        return currentJumpCharge;
    }
}
