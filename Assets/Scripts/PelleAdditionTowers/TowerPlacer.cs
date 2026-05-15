using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public Camera cam;
    public GameObject towerPrefab;
    public LayerMask groundMask;
    public float towerRadius = 0.5f;

    private NonPlacableHighlighter lastHighlighted;

    void Update()
    {
        HighlightCheck();

        if (Input.GetMouseButtonDown(0))
            TryPlaceTower();
    }

    void HighlightCheck()
    {
        // Remove previous highlight
        if (lastHighlighted != null)
        {
            lastHighlighted.Highlight(false);
            lastHighlighted = null;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            var highlighter = hit.collider.GetComponent<NonPlacableHighlighter>();

            if (highlighter != null)
            {
                highlighter.Highlight(true);
                lastHighlighted = highlighter;
            }
        }
    }

    void TryPlaceTower()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            if (!IsValidPlacement(hit.point))
            {
                Debug.Log("Invalid placement area");
                return;
            }

            Instantiate(towerPrefab, hit.point, Quaternion.identity);
        }
    }

    bool IsValidPlacement(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, towerRadius);

        foreach (Collider c in hits)
        {
            if (c.GetComponent<NonPlacableArea>() != null)
                return false;
        }

        return true;
    }
}
