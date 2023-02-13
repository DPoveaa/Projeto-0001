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
    
    [SerializeField] private float dashSpeedHorizontal = 20f;
    [SerializeField] private float dashDelay = 3f;
    [SerializeField] private float dashMax = 2;
    [SerializeField] private float dashSpeedVertical = 8f;
    [SerializeField] private int maxJumps;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float dash;
    private float dashDuration = 0.5f;
    private float dashTimer;
    private bool isDashing = false;
    private float dashTimeCounter;
    private float horizontal;
    private bool isFacingRight = true;
    private int jumps;

    #endregion

    void Start()
    {
        dashTimer = dashDelay;
        horizontal = Input.GetAxisRaw("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashDelay;
    }

    void FixedUpdate()
    {



    }

    void Update()
    {
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!isDashing)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        #region Dash

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dash >= 1)
        {
            isDashing = true;
            dashTimeCounter = dashDuration;
            rb.velocity = new Vector2(horizontal * dashSpeedHorizontal, vertical * dashSpeedVertical);
            dash--;
        }

        if (isDashing)
        {
            dashTimeCounter -= Time.deltaTime;
            if (dashTimeCounter <= 0)
            {
                isDashing = false;
            }
        }

        if (dash <= 0 && dashTimer > 0)
        {
            dashTimer -= 1* Time.deltaTime;
        }

        if (dashTimer <= 0)
        {
            dash = dashMax;
            dashTimer = dashDelay;
        }

        //Debug.Log(dashTimer + " " + dash);



        #endregion

        #endregion

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
        if (horizontal < 0f || horizontal > 0f)
        {
            isFacingRight = !isFacingRight; 
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
