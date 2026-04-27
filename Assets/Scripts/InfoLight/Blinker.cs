using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Blinker : MonoBehaviour
{
    private float currentIntensity;
    private float minIntensity = 10;
    private float maxIntensity = 65;
    private float nextChange;

    private void OnEnable()
    {
        gameObject.GetComponent<Light2D>().intensity = 65;
        currentIntensity = 65;
        StartCoroutine(BackAndForth());
    }
    private void Update()
    {
        
    }
    private IEnumerator BackAndForth()
    {
        while (true)
        {
        if (currentIntensity > maxIntensity || currentIntensity == maxIntensity)
        {
            nextChange = -5;
            currentIntensity += nextChange;
            gameObject.GetComponent<Light2D>().intensity = currentIntensity;
            yield return new WaitForSeconds(0.2f);
        }
        else if (currentIntensity < minIntensity || currentIntensity == minIntensity)
        {
            nextChange = 5;
            currentIntensity += nextChange;
            gameObject.GetComponent<Light2D>().intensity = currentIntensity;
            yield return new WaitForSeconds(0.2f);
        } 
        while (currentIntensity < maxIntensity && currentIntensity > minIntensity)
        {
            currentIntensity += nextChange;
            gameObject.GetComponent<Light2D>().intensity = currentIntensity;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(BackAndForth());
    }
}
