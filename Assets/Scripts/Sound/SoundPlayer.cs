using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource radioSource;





    public void PlaySound(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            radioSource.Play();
    }
}
