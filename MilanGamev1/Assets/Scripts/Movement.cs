using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 velocity;

    [SerializeField] private float Speed = 0f;
    [SerializeField] private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity = Vector2.up * Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity = Vector2.left * Speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity = Vector2.down * Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity = Vector2.right * Speed;
        }
        else
        {
            velocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocity.x, velocity.y);
    }
}
