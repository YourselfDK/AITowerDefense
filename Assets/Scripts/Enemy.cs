using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Path currentPath;
    private Vector3 _targetPosition;
    private int _currentWaypoint;
    
    private void Awake()
    {
        currentPath = GameObject.Find("Path1").GetComponent<Path>();
    }
    private void OnEnable()
    {
        _currentWaypoint = 0;
        _targetPosition = currentPath.GetPosition(_currentWaypoint);   
    }
    void Update()
{
    float currentSpeed;
if (SlowDownButton.isSlowed)
{
    currentSpeed = moveSpeed * 0.5f;
}
else
{
    currentSpeed = moveSpeed;
}

    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, currentSpeed * Time.deltaTime);
    float relativeDistance = (transform.position - _targetPosition).magnitude;
    if (relativeDistance < 0.1f)
    {
        if (_currentWaypoint < currentPath.Waypoints.Length - 1)
        {
            _currentWaypoint++;
            _targetPosition = currentPath.GetPosition(_currentWaypoint);
        }
        else
        {
            if (GetComponent<IntelSnippetRandomizer>().trueInformation == false)
            {
                GameManager.Instance.LoseLifeMistake();
            }
            else
            {
                GameManager.currentLives++;
            }
            Destroy(gameObject);
        }
    }
}
}
