using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 velocity;

    [SerializeField] private float Speed = 0f;
    [SerializeField] private Rigidbody2D rb;
    public Animator animator;

    public Vector2 lookDir;

    // Update is called once per frame
    void Update()
    {
        
        //Input
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        //Movement floats for animation
        animator.SetFloat("Horizontal",velocity.x);
        animator.SetFloat("Vertical",velocity.y);
        animator.SetFloat("Speed",velocity.sqrMagnitude * Speed);
        if (velocity.sqrMagnitude > 0.3){
            animator.SetFloat("prevHorizontal",velocity.x);
            animator.SetFloat("prevVertical",velocity.y);
            lookDir = velocity;
        }
        
    }
    private void FixedUpdate()
    {
        //Setting Velocity

        rb.velocity = velocity * Speed * Time.fixedDeltaTime;
    }
}
