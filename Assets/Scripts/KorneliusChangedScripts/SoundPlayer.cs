using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;
    public AudioSource audioSource;
    
    public AudioClip[] records;

    public AudioClip militaryRadio;
    public AudioClip radioChatter;
    public AudioClip click1;
    public AudioClip click2;
    public AudioClip click3;
    public AudioClip click4;
    public AudioClip click5;
    public AudioClip click6;
    public AudioClip click6v2;
    public AudioClip click7;
    public AudioClip loseLife;
    public AudioClip gainLife;

    //public void PlaySound(InputAction.CallbackContext ctx)
    //{
    //if (ctx.performed)
    //audioSource.PlayOneShot(militaryRadio);
    //}

    public void Awake()
    {
        Instance = this;
    }
    public void clickReact1()
    {
        audioSource.PlayOneShot(click1);
    }
    public void clickReact2()
    {
        audioSource.PlayOneShot(click2);
    }
    public void clickReact3()
    {
        audioSource.PlayOneShot(click3);
    }
    public void clickReact4()
    {
        audioSource.PlayOneShot(click4);
    }
    public void clickReact5()
    {
        audioSource.PlayOneShot(click5);
    }
    public void clickReact6()
    {
        audioSource.PlayOneShot(click6);
    }
    public void clickReact6v2()
    {
        audioSource.PlayOneShot(click6v2);
    }
    public void clickReact7()
    {
        audioSource.PlayOneShot(click7);
    }
    public void loseLifeReact()
    {
        audioSource.PlayOneShot(loseLife);
    }
    public void gainLifeReact()
    {
        audioSource.PlayOneShot(gainLife);
    }
}
