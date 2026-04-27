using UnityEngine;
using UnityEngine.InputSystem;

public class WaveController : MonoBehaviour
{
    public static bool Wave = false; //Is there an active wave?
    public static int currentWave = 1; //The wave number.

   public void startWave()
    {
        Wave = true;
        currentWave++;
        Debug.Log("current wave is:" + currentWave);
        Debug.Log("Wave has started!");
    }

    public void endWave()
    {
        Wave = false;
        Debug.Log("Wave has ended!");
        spawnEnemy.isSpawning = false;
        GameObject enemy = GameObject.FindWithTag("Enemy");     
        Destroy (enemy);
    }
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame && Wave == false)
        {
            startWave();
        }

         if (Keyboard.current.eKey.wasPressedThisFrame && Wave == true)
        {
            GameObject enemy = GameObject.FindWithTag("Enemy");     
            endWave();
        }
    }
}
