using TMPro;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public static VictoryScript Instance { get; private set; }

    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TMP_Text bonusCountText;
    [SerializeField] private TMP_Text secretBonusCountText;
    [SerializeField] private TMP_Text killCountText;

    private int bonusCount;
    private int secretBonusCount;
    private int killCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        bonusCount = 0;
        secretBonusCount = 0;
        killCount = 0;
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

    public void AddSecretBonus()
    {
        secretBonusCount++;
    }

    public void AddKill()
    {
        killCount++;
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
            if (secretBonusCountText != null)
            {
                secretBonusCountText.text = "Secret bonus: " + secretBonusCount;
            }
            if (killCountText != null)
            {
                killCountText.text = "Enemies killed: " + killCount;
            }
        }
    }
}
