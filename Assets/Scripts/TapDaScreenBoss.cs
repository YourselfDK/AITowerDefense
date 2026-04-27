using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapDaScreenBoss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Camera mainCam;

    void Awake()
    {
        // Caching camera in awake to warn us if none is found so we can fix the scene.
        mainCam = Camera.main;
        if (mainCam == null)
            Debug.LogWarning("SimpleClothingInput: No Camera.main found. Assign a camera tagged MainCamera.");
    }

    void Update()
    {
        // Manages touches on device (TouchPhase.Ended for touchscreen, GetMouseButtonUp(0) for mouseclicks when testing)
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                // Just to ignore taps that started over UI, might be subject to change. Just to seperate so UI buttons dont trigger clothing taps. Also seperated ignores for both touch and mouse. 
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(t.fingerId))
                    return;

                TryHandleTap(t.position);
            }
        }
        // Mouse fallback for Editor
        else if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            TryHandleTap(Input.mousePosition);
        }
    }

    private void TryHandleTap(Vector2 position)
    {
        throw new NotImplementedException();
    }
}