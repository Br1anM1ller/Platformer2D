using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Находим объект VictoryScript в сцене и увеличиваем счетчик бонусов
            VictoryScript victoryScript = FindObjectOfType<VictoryScript>();
            if (victoryScript != null)
            {
                victoryScript.AddBonus();
            }
            // Уничтожаем бонус
            Destroy(gameObject);
        }
    }
}
