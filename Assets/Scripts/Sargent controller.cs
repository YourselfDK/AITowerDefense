using UnityEngine;
using UnityEngine.UI;

public class Sargentcontroller : MonoBehaviour
{
    public Button backToGame;
    public GameObject Sargent;
    public RectTransform speechBobble; 
    public GameObject speechThingy; 
    public TMPro.TextMeshProUGUI speechText;
   void Start()
    {
        backToGame.onClick.AddListener(ToGame);
    }
    void ToGame()
    {
       Sargent.SetActive(false); 
    }

     public void ShowSpeech(string text, float xPos, float yPos)
    {
    speechText.text = text;
    speechBobble.gameObject.SetActive(true);
    LayoutRebuilder.ForceRebuildLayoutImmediate(speechBobble);
    speechBobble.anchoredPosition = new Vector2(xPos, yPos);
    }

    public void endOne()
    {
        Sargent.SetActive(true);
        ShowSpeech("You even understand what’s going on yet?", 56f, 218f);
    }

    public void endTwo()
    {
        Sargent.SetActive(true);
    }

    public void endThree()
    {
        Sargent.SetActive(true);
    }

    public void endFive()
    {
        Sargent.SetActive(true);
    }

    public void endSeven()
    {
        Sargent.SetActive(true);
    }
}
