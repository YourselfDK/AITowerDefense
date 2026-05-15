using UnityEngine;

public class RoadColliderGenerator : MonoBehaviour
{
    public Transform[] waypoints;
    public float roadWidth = 1.5f; 

    void Start()
    {
        GenerateRoadColliders();
    }

    void GenerateRoadColliders()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Vector3 start = waypoints[i].position;
            Vector3 end = waypoints[i + 1].position;

        
            GameObject segment = new GameObject("RoadCollider_" + i);
            segment.transform.parent = transform;

            
            Vector3 mid = (start + end) / 2f;
            segment.transform.position = mid;

      
            segment.transform.LookAt(end);

         
            BoxCollider col = segment.AddComponent<BoxCollider>();

            float length = Vector3.Distance(start, end);

            col.size = new Vector3(roadWidth, 1f, length);
            col.center = Vector3.zero;

       
            segment.AddComponent<NonPlacableArea>();
        }
    }
}
