using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public AudioSource dashSFX;
    private float horizontal;
    public float movementSpeed;
    //Jump Variables
    public float jumpForce = 7.0f;
    public int maxJumps = 2;
    public Animator animator;

    private Rigidbody2D rb;
    private int jumpsRemaining;

    //Ground Stuff
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;


    //Wall Jump Variables
    public Transform wallCheck;
    public LayerMask wallLayer;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(8f, 16f);


    //Dash Variables
    public bool canDash = true;
    private bool isFacingRight = true;
    private bool isDashing;
    private float dashingPower = 40f;
    private float dashingTime = 0.25f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // Move left/right
        horizontal = Input.GetAxisRaw("Horizontal");
        if(isWallTouch && !isGrounded && horizontal != 0)
        {
            isSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            //Debug.Log("IsTouchWall");
        }
        else
        {
            isSliding = false;
            //Debug.Log("IsNOTTouchWall");
        }
        WallJump();
        //Debug.Log(wallJumpingCounter);

        Jump();

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
            dashSFX.Play();
        }

        // Wall Jump
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.58f, 0.27f), 0, groundLayer);
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.3f, 0.84f), 0, wallLayer);

        
        if (!isWallJumping)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        // Dash
        if (isDashing)
        {
            return;
        }

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
            if (horizontal != 0f)
            {
                animator.Play("Walk");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }

    
    }

    

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
            
            /*isFacingRight = !isFacingRight;

            if (isFacingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            */
            
        }
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
        }

    }

     private void WallJump()
    {
        if (isSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
                /*isFacingRight = !isFacingRight;
                if (isFacingRight)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                */
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        //rb.AddForce(transform.localScale.x * dashingPower, ForceMode2D.Impulse);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}


