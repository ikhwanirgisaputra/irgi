using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    void Update()
    {
        // Input dari pemain (horizontal dan vertikal)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Set parameter animator berdasarkan input
        if (movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        // Gerakkan karakter
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
