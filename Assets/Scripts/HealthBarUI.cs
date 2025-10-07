using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image healthBarFill;
    
    private void Update()
    {
        if (playerHealth != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = playerHealth.GetHealthPercentage();
        }
    }
}
