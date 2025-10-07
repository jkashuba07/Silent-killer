using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool isFacingRight = true;
    
    private PlayerAnimationController animController;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<PlayerAnimationController>();
    }
    
    private void Update()
    {
        // Get input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        
        // Update animations
        if (animController != null)
        {
            animController.SetMoving(Mathf.Abs(horizontalInput) > 0.01f);
            animController.SetGrounded(isGrounded);
        }
    }
    
    private void FixedUpdate()
    {
        // Apply horizontal movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        
        // Flip character sprite based on direction
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (animController != null)
        {
            animController.TriggerJump();
        }
    }
    
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    public bool IsFacingRight()
    {
        return isFacingRight;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
