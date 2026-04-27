using System.Collections;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] float spamRate;
    public static bool isSpawning = false;
    int enemiesSpawned = 0;
    int maxEnemies = 25;
    Vector2 spawnPos;
    void Start()
    {
        
        spawnPos = GameObject.Find("SpawnPoint").transform.position;
        
    }
    void Update()
    {
        if (WaveController.Wave == true && isSpawning == false)
        {
            StartSpawning();
        }
    }
    void ToturialEnemy()
    {
        
    }
    void SpawnEnemy()
{
    if (enemiesSpawned >= maxEnemies)
    {
        CancelInvoke(nameof(SpawnEnemy));
        return;
    }

    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    enemiesSpawned++;

    Debug.Log("Enemy was spawned, current number:" + enemiesSpawned);
}
    void StartSpawning()
    {   
        isSpawning = true; 

        if (WaveController.currentWave == 1) //currentWave == 1 would be a toturial state. 
        {
            ToturialEnemy();
        }
        else if (WaveController.currentWave == 2) //These could then make things harder.
        {
            
            InvokeRepeating("SpawnEnemy", 0.5f, spamRate);
        } 
}

}
