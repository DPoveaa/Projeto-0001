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
    [SerializeField] private Transform wallCheck1;
    [SerializeField] private Transform wallCheck2;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;

    private float dash;
    private float dashDuration = 0.5f;
    private float dashTimer;
    private bool isDashing = false;
    private float dashTimeCounter;
    private bool isFacingRight = true;
    private int jumps;

    #endregion

    void Start()
    {
        dashTimer = dashDelay;
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashDelay;
    }

    void FixedUpdate()
    {
        


    }

    void Update()
    {

        #region Movement mechanics

        float horiz = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        if (!isDashing)
        {
            rb.velocity = new Vector2(horiz * speed, rb.velocity.y);
        }

        #region Dash

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dash >= 1)
        {
            isDashing = true;
            dashTimeCounter = dashDuration;
            rb.velocity = new Vector2(horiz * dashSpeedHorizontal, verti * dashSpeedVertical);
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

        #region OnWall mechanics

        #endregion

        Flip();
    }

    #region WallCheck
    private bool OnWall()
    {
        return Physics2D.OverlapCircle(wallCheck1.position, 0.2f, wallLayer);

    }

    private bool OnWall2()
    {
        return Physics2D.OverlapCircle(wallCheck2.position, 0.2f, wallLayer);
    }

    #endregion

    #region GroundCheck

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    #endregion

    private void Flip()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
