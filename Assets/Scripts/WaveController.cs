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

    void Start()
    {
        currentWave = 1;
        Wave = false;
        UpdateUI();
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
        Wave = false;
        spawnEnemy.isSpawning = false;
        spawnEnemy.queueFinished = false;
        GameObject enemy = GameObject.FindWithTag("Enemy");
        Destroy(enemy);
    }

    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame && !Wave)
            startWave();

        if (Keyboard.current.eKey.wasPressedThisFrame && Wave)
            endWave();
    }
}