using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Lives")]
    public int maxLives = 100;
    public int currentLives;
    public static int currentLivesByMistake;

    [Header("UI")]
    public TMP_Text livesText;

    void Awake()
    {
        Instance = this;
        currentLives = maxLives;
        UpdateUI();
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void LoseLifeMistake()
    {
        currentLivesByMistake++;
        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + currentLives;
    }
}