using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runSpeed = 0.6f;
    public float jumpForce = 2.6f;

    public Sprite jumpSprite;

    private Rigidbody2D body;
    private SpriteRenderer sr;
    private Animator animator;

    private bool isGrounded;
    public bool isMoving;
    public GameObject groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detect movement and set isMoving parameter
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        animator.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Move(horizontalInput);
    }

    private void Move(float horizontalInput)

    {
        if (horizontalInput != 0) // Player is moving horizontally
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        body.velocity = new Vector2(horizontalInput * runSpeed, body.velocity.y);

        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        else if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.transform.position, groundCheckRadius);
    }
}
