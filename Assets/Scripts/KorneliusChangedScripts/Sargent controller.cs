using UnityEngine;
using UnityEngine.UI;

public class Sargentcontroller : MonoBehaviour
{
    public Button backToGame;
    public GameObject Sargent;
    public RectTransform speechBobble; 
    public GameObject speechThingy; 
    public TMPro.TextMeshProUGUI speechText;
    //public AudioSource audioSource;
    //Changing AudioSource to a theoretical SoundPlayer in the same scene. (It is not in there right now)
    //public AudioClip sigh;
    //public AudioClip clearsthroat;
    //public AudioClip grunt;
    //public AudioClip growl;

    private string Curtext;
    private float CurXPos;
    private float CurYPos;

    void Start()
    {
        backToGame.onClick.AddListener(ToGame);
    }
    void ToGame()
    {
       Sargent.SetActive(false); 
    }

    public void ActivateNextStep(int StepOf)
    {
        string Curtext(int StepOf)
        {
            switch(StepOf)
            {
                case 1:
                    "You even understand what’s going on yet?";
                    break;
                case 2:
                    "Hmmm, but even a child could have caught that.";
                    break;
                case 2:
                    "I guess I’ll leave you to your work.";
                    break;
                case 2:
                    "01001101 01100001 01111001 01100010 01100101 00100000 01111001 01101111 01110101 00100111 01110010 01100101 00100000 01101110 01101111 01110100 00100000 01101000 01100001 01101100 01100110 00100000 01100010 01100001 01100100";
                    break;
                case 2:
                    "This must be the last wave!";
                    break;
                default:
                    "CodeBrokenForSomeReason";
                    break;
            }
        }

        //As there are no other options currently, I am just manually setting the x and y here, though leaving/implying the option to make
        //them dynamic by not putting them in start.
        CurXPos = 56f;
        CurYPos = 218f;

        ShowSpeech(Curtext, xPos, yPos);
    }
    
    private void ShowSpeech(string text, float xPos, float yPos)
    {
    speechText.text = text;
    speechBobble.gameObject.SetActive(true);
    LayoutRebuilder.ForceRebuildLayoutImmediate(speechBobble);
    speechBobble.anchoredPosition = new Vector2(xPos, yPos);
    }

        //The switch function after this here would have to be split into two if I wanted to use it, but it is unneccessary, as the values are currently unchanging.
        /*private float yPos float xPos LineToSpeak(int StepOf)
        {
            switch(StepOf)
            {
                case 1:
                    56f; 218f;
                    break;
                case 2:
                    56f; 218f;
                    break;
                case 2:
                    56f; 218f;
                    break;
                case 2:
                    56f; 218f;
                    break;
                case 2:
                    56f; 218f;
                    break;
                default:
                    56f; 218f;
                    break;
            }
        }*/
        
    

    public void EndOne()
    {
        Sargent.SetActive(true);
        ShowSpeech("You even understand what’s going on yet?", 56f, 218f);
    }

    public void EndTwo()
    {
        Sargent.SetActive(true);
        //audioSource.PlayOneShot(clearsthroat);
        ShowSpeech("Hmmm, but even a child could have caught that.", 56f, 218f);
    }

    public void EndThree()
    {
        Sargent.SetActive(true);
        //audioSource.PlayOneShot(sigh);
        ShowSpeech("I guess I’ll leave you to your work.", 56f, 218f);
    }

    public void EndFive()
    {
        Sargent.SetActive(true);
        //audioSource.PlayOneShot(growl);
        ShowSpeech("01001101 01100001 01111001 01100010 01100101 00100000 01111001 01101111 01110101 00100111 01110010 01100101 00100000 01101110 01101111 01110100 00100000 01101000 01100001 01101100 01100110 00100000 01100010 01100001 01100100", 56f, 808f);
    }

    public void EndSeven()
    {
        Sargent.SetActive(true);
        //audioSource.PlayOneShot(grunt);
        ShowSpeech("This must be the last wave!", 56f, 218f);
    }
}
