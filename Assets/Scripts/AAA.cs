using UnityEngine;

public class AAA : MonoBehaviour
{
    WaveController WC;

    void Start()
    {
        WC = gameObject.GetComponent<WaveController>();
    }
    public void GoGoGO()
    {
        WC.startWave();
    }
}
