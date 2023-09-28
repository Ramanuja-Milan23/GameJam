using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 faceDir;

    [SerializeField] private float Speed = 0f;
    [SerializeField] private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        faceDir = new Vector2(0, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        if(velocity.magnitude > 0.5f) faceDir = velocity.normalized;

        //Movement floats for animation
        animator.SetFloat("Horizontal",velocity.x);
        animator.SetFloat("Vertical",velocity.y);
        animator.SetFloat("Speed",velocity.sqrMagnitude * Speed);
        
    }
    private void FixedUpdate()
    {
        //Setting Velocity
        rb.velocity = velocity * Speed * Time.fixedDeltaTime;
    }
}
