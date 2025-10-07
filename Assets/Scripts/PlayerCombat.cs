using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Weak Attack Settings")]
    [SerializeField] private float weakAttackDamage = 10f;
    [SerializeField] private float weakAttackCooldown = 0.3f;
    [SerializeField] private float weakAttackRange = 1.5f;
    
    [Header("Strong Attack Settings")]
    [SerializeField] private float strongAttackDamage = 25f;
    [SerializeField] private float strongAttackCooldown = 0.8f;
    [SerializeField] private float strongAttackRange = 2f;
    
    [Header("Attack Points")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    
    private float lastWeakAttackTime;
    private float lastStrongAttackTime;
    private PlayerAnimationController animController;
    
    private void Awake()
    {
        animController = GetComponent<PlayerAnimationController>();
    }
    
    private void Update()
    {
        // Weak Attack Input
        if (Input.GetButtonDown("WeakAttack"))
        {
            if (Time.time >= lastWeakAttackTime + weakAttackCooldown)
            {
                PerformWeakAttack();
            }
        }
        
        // Strong Attack Input
        if (Input.GetButtonDown("StrongAttack"))
        {
            if (Time.time >= lastStrongAttackTime + strongAttackCooldown)
            {
                PerformStrongAttack();
            }
        }
    }
    
    private void PerformWeakAttack()
    {
        lastWeakAttackTime = Time.time;
        
        // Trigger animation
        if (animController != null)
        {
            animController.TriggerWeakAttack();
        }
        
        // Deal damage to enemies in range
        DealDamage(weakAttackDamage, weakAttackRange);
    }
    
    private void PerformStrongAttack()
    {
        lastStrongAttackTime = Time.time;
        
        // Trigger animation
        if (animController != null)
        {
            animController.TriggerStrongAttack();
        }
        
        // Deal damage to enemies in range
        DealDamage(strongAttackDamage, strongAttackRange);
    }
    
    private void DealDamage(float damage, float range)
    {
        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);
        
        // Damage each enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            // If enemy has health component, deal damage
            var enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        // Draw weak attack range in yellow
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, weakAttackRange);
        
        // Draw strong attack range in red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, strongAttackRange);
    }
}
