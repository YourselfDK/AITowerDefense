using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class boosterAbilties : MonoBehaviour
{
    //Booster one, healing for 10 seconds, using the GainLife method from GameManager.cs.

    public GameManager GM;
    public void Healing()
    {
        StartCoroutine(HealForTime(10f));
        pointShop.pointController(-20);
    }

    private IEnumerator HealForTime(float duration)
    {
        float interval = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            GM.GainLife();
            Debug.Log(elapsed);

            yield return new WaitForSeconds(interval);
            elapsed += interval;
        }
    }

    //Booster 2, finding and checking the trueInformation bool from IntelSnippetRandomizer. 
    //Using this information, it kills a random, active enemy on the field, with the enemy tag.

    public void KillRandom()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        List<GameObject> falseEnemies = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            IntelSnippetRandomizer intel = enemy.GetComponent<IntelSnippetRandomizer>();

            if (intel.trueInformation == false)
            {
                falseEnemies.Add(enemy);
            }
        }

        if (falseEnemies.Count == 0)
            return;

        pointShop.pointController(-15);

        int randomIndex = Random.Range(0, falseEnemies.Count);
        Debug.Log(falseEnemies.Count);

        GameObject target = falseEnemies[randomIndex];

        Destroy(target);
        Debug.Log("Target Destroyed");

        spawnEnemy.activeEnemies--;
        pointShop.pointController(+1);
    }

    //Booster 3, this slows down the enemies for 10 seconds, allowing the player more time to read each string.

    private bool speed = false;
    public void Slowmotion()
    {
        if (speed == false)
        {
            pointShop.pointController(-15);
            speed = true;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Enemy enemySpeed = enemy.GetComponent<Enemy>();
                enemySpeed.SetMoveSpeed(0.1f);
            }
            StartCoroutine(SlowEnemiesDown(10f));
            Debug.Log("Speed has been slowed.");
        }
    }

    private IEnumerator SlowEnemiesDown(float duration) 
    {
        yield return new WaitForSeconds(duration);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Enemy enemySpeed = enemy.GetComponent<Enemy>();
            enemySpeed.SetMoveSpeed(0.4f);
        }

        speed = false;
        Debug.Log("Speed has returned to normal.");
    }

    //Booster 4, this finds out if the enemy intel is true or false, using the same technic as before.
    //For a period of six seconds, this is then displayed in the panel.

    public static bool TruthOnline = false;
    public static TMP_Text TruthText;
    public void TellTheTruth()
    {
        pointShop.pointController(-35);
        TruthOnline = true;    //This is used in the enemyInspectorPanel.cs. 
        StartCoroutine(TrueOrFalse(6f));
    }

    private IEnumerator TrueOrFalse(float duration)
    { 
        yield return new WaitForSeconds(duration);

        TruthOnline = false;
    }
}
