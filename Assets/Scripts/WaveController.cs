// WaveController.cs
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WaveController : MonoBehaviour
{
    public static bool Wave = false;
    public static int currentWave = 1;

    [Header("UI")]
    public TMP_Text waveText;
    public static int endNumber = 0;

    Sargentcontroller SC; 

    void Start()
    {
        currentWave = 1;
        Wave = false;
        UpdateUI();
        gameObject.GetComponent<Sargentcontroller>();

    }

    void UpdateUI()
    {
        if (waveText != null)
            waveText.text = "Wave: " + (currentWave - 1);
    }

    public void startWave()
    {
        Wave = true;
        currentWave++;
        spawnEnemy.isSpawning = false;
        spawnEnemy.queueFinished = false;
        UpdateUI();
    }

    public void endWave()
    {
        endNumber++;
        GameManager.currentLives+=2;
        Wave = false;
        spawnEnemy.isSpawning = false;
        spawnEnemy.queueFinished = false;
        GameObject enemy = GameObject.FindWithTag("Enemy");
        Destroy(enemy);

        if (endNumber == 1)
        {
            SC.endOne();
        }
        else if (endNumber == 2)
        {
            SC.endTwo();
        }
        else if (endNumber == 3)
        {
            SC.endThree();
        }
        else if (endNumber == 5)
        {
            SC.endFive();
        }
        else if (endNumber == 7)
        {
            SC.endSeven();
        }
    }

    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame && !Wave)
            startWave();

        if (Keyboard.current.eKey.wasPressedThisFrame && Wave)
            endWave();
    }
}