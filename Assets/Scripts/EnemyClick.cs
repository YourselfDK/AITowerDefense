using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyClick : MonoBehaviour, IPointerClickHandler
{
    IntelSnippetRandomizer intel;
    EnemyInspectorPanel panel;

    void Awake()
    {
        intel = GetComponent<IntelSnippetRandomizer>();
        panel = GetComponentInChildren<EnemyInspectorPanel>(true); // true = include inactive
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.Open(intel);
    }
}