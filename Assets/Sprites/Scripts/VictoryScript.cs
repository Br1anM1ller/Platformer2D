using TMPro;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TMP_Text bonusCountText;  // Поле для текста

    private int bonusCount;

    private void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        bonusCount = 0;  // Инициализируем счетчик бонусов
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowVictory();
        }
    }

    public void AddBonus()
    {
        bonusCount++;
    }

    private void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            if (bonusCountText != null)
            {
                bonusCountText.text = "Bonuses collected: " + bonusCount;
            }
        }
    }
}
