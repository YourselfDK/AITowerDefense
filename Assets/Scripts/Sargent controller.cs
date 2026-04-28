using UnityEngine;
using UnityEngine.UI;

public class Sargentcontroller : MonoBehaviour
{
    public Button backToGame;
    public GameObject Sargent;
    public RectTransform speechBobble; 
    public GameObject speechThingy; 
    public TMPro.TextMeshProUGUI speechText;
    public AudioSource audioSource;
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
        ShowSpeech("Hmmm, but even a child could have caught that.", 56f, 218f);
    }

    public void endThree()
    {
        Sargent.SetActive(true);
        ShowSpeech("I guess I’ll leave you to your work.", 56f, 218f);
    }

    public void endFive()
    {
        Sargent.SetActive(true);
        ShowSpeech("01001101 01100001 01111001 01100010 01100101 00100000 01111001 01101111 01110101 00100111 01110010 01100101 00100000 01101110 01101111 01110100 00100000 01101000 01100001 01101100 01100110 00100000 01100010 01100001 01100100", 56f, 808f);
    }

    public void endSeven()
    {
        Sargent.SetActive(true);
        ShowSpeech("This must be the last wave!", 56f, 218f);
    }
}
