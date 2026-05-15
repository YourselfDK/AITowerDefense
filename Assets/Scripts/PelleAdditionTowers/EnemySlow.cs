using UnityEngine;
using System.Collections;

public class EnemySlow : MonoBehaviour
{
    public float currentSpeedMultiplier = 1f;
    private Coroutine slowRoutine;

    public void ApplySlow(float multiplier, float duration)
    {
        if (slowRoutine != null)
            StopCoroutine(slowRoutine);

        slowRoutine = StartCoroutine(SlowEffect(multiplier, duration));
    }

    private IEnumerator SlowEffect(float multiplier, float duration)
    {
        currentSpeedMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeedMultiplier = 1f;
    }
}
