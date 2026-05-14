using UnityEngine;
using UnityEngine.UI;

public class SlowDownButton : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int lifeCost = 5;
    [SerializeField] float slowDuration = 5f;
    [SerializeField] float slowMultiplier = 0.5f;

    [Header("UI")]
    public Button slowButton;

    public static bool isSlowed = false;

    void Start()
    {
        slowButton.onClick.AddListener(ActivateSlow);
    }

    void ActivateSlow()
    {
        if (GameManager.currentLives <= lifeCost)
        {
            Debug.Log("Not enough lives!");
            return;
        }

        if (isSlowed)
            return;

        GameManager.Instance.LoseLife();
        GameManager.Instance.LoseLife();
        GameManager.Instance.LoseLife();
        GameManager.Instance.LoseLife();
        GameManager.Instance.LoseLife();

        isSlowed = true;
        Invoke(nameof(RemoveSlow), slowDuration);
    }

    void RemoveSlow()
    {
        isSlowed = false;
    }
}