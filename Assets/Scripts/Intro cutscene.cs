using UnityEngine;

public class Introcutscene : MonoBehaviour
{
    public RectTransform myImage;   // drag your UI Image here in Inspector
    public Vector2 targetPosition = new Vector2(-220f, -400f);
    public float speed = 5f;

    public AudioSource audioSource;
    public AudioClip footsteps;
    public AudioClip speaking;
    bool enteredScene = false;
    public GameObject speechBobble; 
    public GameObject speechThingy; 
    public TMPro.TextMeshProUGUI speechText;

    void Start()
    {
        
    }
    void Update()
    {
        if (enteredScene == false)
        {
           if (Vector2.Distance(myImage.anchoredPosition, targetPosition) > 0.1f)
            {
                if (!audioSource.isPlaying) 
                {
                    audioSource.clip = footsteps;
                    audioSource.loop = true;
                    audioSource.Play();
                }
                myImage.anchoredPosition = Vector2.MoveTowards(
                myImage.anchoredPosition,
                targetPosition,
                speed * Time.deltaTime
            );
            } 
            else
            {
            enteredScene = true;

            audioSource.Stop(); 
            audioSource.PlayOneShot(speaking);
            speechText.text = "At ease soldier!";
            speechBobble.SetActive(true);
            speechThingy.SetActive(true);
            }
        }
        
    }

    public void ShowSpeech(string text)
{
    speechText.text = text;
    speechBobble.SetActive(true);
}

}
