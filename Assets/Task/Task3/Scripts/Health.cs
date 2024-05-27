using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameOverUI gameOverUI;

    private Animator animator;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }

        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        CheckIsAlive();

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0 && isAlive)
        {
            isAlive = false;
            Die();
        }
    }

    private void Die()
    {
        if (CompareTag("Player"))
        {
            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }

            if (animator != null)
            {
                animator.SetBool("IsDeath", true);
            }

            if (GetComponent<Shooter>() != null)
            {
                GetComponent<Shooter>().enabled = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}