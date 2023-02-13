using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Public variables



    #endregion

    #region Private variables
    [SerializeField] private int maxJumps;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private float horizontal;
    private bool isFacingRight = true;
    private int jumps;
    #endregion

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        #region Movement

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        #endregion

    }

    void Update()
    {

        #region Jump mechanics

        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            jumps--;
        }

        #region Reset jump

        if (IsGrounded())
        {
            jumps = maxJumps;
        }

        #endregion

        #endregion

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
