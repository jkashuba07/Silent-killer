using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    
    [Header("Regeneration Settings")]
    [SerializeField] private float healthRegenRate = 5f; // Health per second
    [SerializeField] private float regenDelay = 2f; // Delay before regen starts
    
    private float timeSinceLastDamage;
    private bool canRegenerate;
    
    private void Start()
    {
        currentHealth = maxHealth;
        timeSinceLastDamage = 0f;
    }
    
    private void Update()
    {
        // Check if there are enemies on screen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        canRegenerate = enemies.Length == 0;
        
        // Regenerate health if no enemies are present
        if (canRegenerate && currentHealth < maxHealth)
        {
            timeSinceLastDamage += Time.deltaTime;
            
            if (timeSinceLastDamage >= regenDelay)
            {
                RegenerateHealth();
            }
        }
    }
    
    private void RegenerateHealth()
    {
        currentHealth += healthRegenRate * Time.deltaTime;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        timeSinceLastDamage = 0f;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("Player has died!");
        // Add death logic here (e.g., game over, respawn)
    }
    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    
    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
