using System.Collections;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] float spamRate;
    public static bool isSpawning = false;
    int enemiesSpawned = 0;
    int maxEnemies = 25;

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

        float Xloc = -2.5f;
        //randomX = Random.Range(0f, 1f); //Note, position code is tempoary, since we don't currently have spawn cords decided, and I need to test.
        float Yloc = 4.25f;
        //randomY = Random.Range(0f, 1f);

        Vector2 viewportPos = new Vector2(Xloc, Yloc);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);
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
