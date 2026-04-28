using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyClick : MonoBehaviour, IPointerClickHandler
{
    private SoundPlayer soundPlayer;
    IntelSnippetRandomizer intel;
    EnemyInspectorPanel panel;

    void Awake()
    {
        intel = GetComponent<IntelSnippetRandomizer>();
        panel = GetComponentInChildren<EnemyInspectorPanel>(true); // true = include inactive
         soundPlayer = GetComponent<SoundPlayer>();
        if (soundPlayer == null)
            Debug.LogWarning("EnemyClick: No SoundPlayer found on this GameObject.");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.Open(intel);
         soundPlayer?.clickReact3();
    }
}