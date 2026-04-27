using System.Collections;
using System.Numerics;
using UnityEngine;
usinfg System.Collections.Generic;
using UnityEngine;

public class BlinkerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rb;

    private Transform checkpoint;

    private int index = 0;

void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        checkpoint = BlinkerManager.main.checkpoints[index];
    }

    // Update is called once per frame
    void Update()
    {
        checkpoint = BlinkerManager.main.checkpoints[index];
        if (Vector2.Distance(transform.position, checkpoint.position) < 0.1f)
        {
            index++;
            if (index >= BlinkerManager.main.checkpoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }
}
