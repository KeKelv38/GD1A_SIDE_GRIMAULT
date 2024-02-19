using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private float move;
    public Animator animator;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask groundLayer2;

    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow) && IsGrounded2())
        {
            rb.velocity = new Vector2((speed/2) * move, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) && IsGrounded2())
        {
            rb.velocity = new Vector2((speed/2) * move, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    private void FixedUptade()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer2);
    }

    private void Flip()
    {
        if (isFacingRight && move < 0f || !isFacingRight && move > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
