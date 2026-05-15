using UnityEngine;
using System.Collections;

public class EMPTower : MonoBehaviour
{
    [Header("EMP Settings")]
    public float fireInterval = 2f;
    public float slowDuration = 1f;
    public float slowMultiplier = 0.5f;
    public float range = 5f;

    [Header("Animation")]
    public Animator animator;
    public string chargeAnimation = "EMP_Charge";
    public string fireAnimation = "EMP_Fire";

    [Header("Range Preview")]
    public GameObject rangeCircle;

    private float timer;

    void Start()
    {
        if (rangeCircle != null)
        {
            float diameter = range * 2f;
            rangeCircle.transform.localScale = new Vector3(diameter, diameter, 1f);
            rangeCircle.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            timer = 0f;
            StartCoroutine(FireSequence());
        }
    }

    IEnumerator FireSequence()
    {
        if (animator != null)
            animator.Play(chargeAnimation);

        yield return new WaitForSeconds(0.3f);

        if (animator != null)
            animator.Play(fireAnimation);

        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        foreach (Collider hit in hits)
        {
            EnemySlow slow = hit.GetComponent<EnemySlow>();
            if (slow != null)
                slow.ApplySlow(slowMultiplier, slowDuration);
        }
    }
   
    public void ShowRange(bool show)
    {
        if (rangeCircle != null)
            rangeCircle.SetActive(show);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
