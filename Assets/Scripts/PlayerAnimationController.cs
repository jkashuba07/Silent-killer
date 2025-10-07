using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    
    // Animation parameter names
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int WeakAttack = Animator.StringToHash("WeakAttack");
    private static readonly int StrongAttack = Animator.StringToHash("StrongAttack");
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetMoving(bool isMoving)
    {
        if (animator != null)
        {
            animator.SetBool(IsMoving, isMoving);
        }
    }
    
    public void SetGrounded(bool isGrounded)
    {
        if (animator != null)
        {
            animator.SetBool(IsGrounded, isGrounded);
        }
    }
    
    public void TriggerJump()
    {
        if (animator != null)
        {
            animator.SetTrigger(Jump);
        }
    }
    
    public void TriggerWeakAttack()
    {
        if (animator != null)
        {
            animator.SetTrigger(WeakAttack);
        }
    }
    
    public void TriggerStrongAttack()
    {
        if (animator != null)
        {
            animator.SetTrigger(StrongAttack);
        }
    }
}
