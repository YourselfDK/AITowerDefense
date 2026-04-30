using UnityEngine;
using TMPro;

public class EnemyInspectorPanel : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panel;

    [Header("Text Field")]
    public TMP_Text displayText;

    IntelSnippetRandomizer intel;

    
    void Awake()
    {
        panel.SetActive(false);
    }

    public void Open(IntelSnippetRandomizer intelRef)
    {
        intel = intelRef;
        displayText.text = intel.myTextField.text;
        panel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
    }

    public void Kill()
    {
        if (intel.trueInformation == true)
        {
            GameManager.Instance.LoseLifeMistake();
        }
        Destroy(intel.gameObject);
        spawnEnemy.activeEnemies--;
    }
}