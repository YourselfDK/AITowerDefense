using UnityEngine;
using TMPro;

public class EnemyInspectorPanel : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panel;

    [Header("Text Field")]
    public TMP_Text displayText;

    IntelSnippetRandomizer intel;

    public TMP_Text trueFalse; //I've added this line.
    void Awake()
    {
        panel.SetActive(false);
    }

    public void Open(IntelSnippetRandomizer intelRef)
    {
        intel = intelRef;
        displayText.text = intel.myTextField.text;
        panel.SetActive(true);
        if (boosterAbilties.TruthOnline == true)   //I've added from here...
        {
            if (intel.trueInformation == true)
            {
                trueFalse.text = "True";
                trueFalse.color = Color.green;
                trueFalse.fontStyle = TMPro.FontStyles.Bold;
            }
            else if (intel.trueInformation == false)
            {
                trueFalse.text = "False";
                trueFalse.color = Color.red;
                trueFalse.fontStyle = TMPro.FontStyles.Bold;
            }
            trueFalse.gameObject.SetActive(true); //... To here.
        }
    }

    public void Close()
    {
        panel.SetActive(false);
        trueFalse.gameObject.SetActive(false); //Also added this.
    }

    public void Kill()
    {
        if (intel.trueInformation == true)
        {
            GameManager.Instance.LoseLifeMistake();
        }
        else if (intel.trueInformation == false)
        {
            pointShop.pointController(+1); //I've added this line.
        }
            Destroy(intel.gameObject);
        spawnEnemy.activeEnemies--;
        trueFalse.gameObject.SetActive(false); //And this.
    }
}