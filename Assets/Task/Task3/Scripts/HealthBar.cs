using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetMaxHealth(float health)
    {
        fillImage.fillAmount = 1f;
    }

    public void SetHealth(float health, float maxHealth)
    {
        fillImage.fillAmount = health / maxHealth;
    }
}