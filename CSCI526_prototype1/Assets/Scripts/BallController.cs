using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject ball;
    private bool isGrounded = true;

    // 自动运动的速度
    public float autoMoveSpeed = 20.0f;

    // 跳跃的力量
    public float jumpForce = 5.0f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // 自动向右移动
        AutoMoveRight();

        // 检测是否按下跳跃键
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

   
    }

    private void AutoMoveRight()
    {
        // 球自动向右移动
        rb.velocity = new Vector2(autoMoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        // 向右和向上同时施加力
        rb.velocity = new Vector2(autoMoveSpeed, jumpForce);
        isGrounded = false;
    }
}
