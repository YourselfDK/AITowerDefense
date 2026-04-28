using UnityEngine;

public class NonPlacableHighlighter : MonoBehaviour
{
    public Material highlightMaterial;

    private Material originalMaterial;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalMaterial = rend.material;
    }

    public void Highlight(bool state)
    {
        if (rend == null) return;

        if (state)
            rend.material = highlightMaterial;
        else
            rend.material = originalMaterial;
    }
}
