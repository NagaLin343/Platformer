using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Hero: MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 15f;
    private int lives = 5;
    private bool isGrounded;
    public float rayDistance = 1.6f;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    
    private void Awake()
    {
        float tr= Math.Min(speed, jumpForce);
        rb = GetComponent<Rigidbody2D>();
        sprite= GetComponentInChildren<SpriteRenderer>();
    }


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if ( Input.GetButton("Jump")&&isGrounded)
        {

            Jump();
        }

    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position,transform.position+dir,speed*Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }


    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

}
