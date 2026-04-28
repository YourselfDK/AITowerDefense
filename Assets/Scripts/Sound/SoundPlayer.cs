using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip militaryRadio;
    public AudioClip radioChatter;


    public void PlaySound(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            audioSource.PlayOneShot(militaryRadio);
    }
}
