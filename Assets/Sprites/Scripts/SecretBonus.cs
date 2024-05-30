using UnityEngine;

public class SecretBonus : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            VictoryScript victoryScript = FindObjectOfType<VictoryScript>();
            if (victoryScript != null)
            {
                victoryScript.AddSecretBonus();
            }
            isCollected = true; // Обновляем флаг, чтобы бонус засчитался только один раз
            Destroy(gameObject);
        }
    }
}