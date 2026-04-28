// spawnEnemy.cs
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public int redCount;
    public int blueCount;
    public int greenCount;
}

public class spawnEnemy : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject greenPrefab;

    [Header("Spawn Settings")]
    [SerializeField] float spawnRate;
    public static bool isSpawning = false;
    public static bool queueFinished = false;

    [Header("Wave Data")]
    public WaveData[] waves = new WaveData[]
    {
        new WaveData { redCount = 5,  blueCount = 0, greenCount = 0 }, // Round 1
        new WaveData { redCount = 8,  blueCount = 0, greenCount = 0 }, // Round 2
        new WaveData { redCount = 5,  blueCount = 2, greenCount = 0 }, // Round 3
        new WaveData { redCount = 0,  blueCount = 5, greenCount = 0 }, // Round 4
        new WaveData { redCount = 0,  blueCount = 8, greenCount = 0 }, // Round 5
        new WaveData { redCount = 1,  blueCount = 6, greenCount = 1 }, // Round 6
        new WaveData { redCount = 0,  blueCount = 5, greenCount = 3 }, // Round 7
        new WaveData { redCount = 0,  blueCount = 0, greenCount = 6 }, // Round 8
    };

    Vector2 spawnPos;
    GameObject[] spawnQueue;
    int spawnIndex = 0;

    void Start()
    {
        spawnPos = GameObject.Find("SpawnPoint").transform.position;
        isSpawning = false;
        queueFinished = false;
    }

    void Update()
    {
        if (WaveController.Wave && !isSpawning && !queueFinished)
            StartSpawning();
    }

    void StartSpawning()
    {
        isSpawning = true;
        spawnIndex = 0;

        int waveIndex = WaveController.currentWave - 2;

        if (waveIndex < 0 || waveIndex >= waves.Length)
        {
            isSpawning = false;
            return;
        }

        WaveData wave = waves[waveIndex];
        int total = wave.redCount + wave.blueCount + wave.greenCount;

        if (total == 0)
        {
            isSpawning = false;
            return;
        }

        spawnQueue = new GameObject[total];

        int i = 0;
        for (int r = 0; r < wave.redCount; r++)  spawnQueue[i++] = redPrefab;
        for (int b = 0; b < wave.blueCount; b++)  spawnQueue[i++] = bluePrefab;
        for (int g = 0; g < wave.greenCount; g++) spawnQueue[i++] = greenPrefab;

        for (int s = spawnQueue.Length - 1; s > 0; s--)
        {
            int rand = Random.Range(0, s + 1);
            GameObject temp = spawnQueue[rand];
            spawnQueue[rand] = spawnQueue[s];
            spawnQueue[s] = temp;
        }

        InvokeRepeating(nameof(SpawnEnemy), 0.5f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (spawnIndex >= spawnQueue.Length)
        {
            CancelInvoke(nameof(SpawnEnemy));
            queueFinished = true;
            WaveController.Wave = false;
            return;
        }

        Instantiate(spawnQueue[spawnIndex], spawnPos, Quaternion.identity);
        spawnIndex++;
    }
}