using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Player
{
    public abstract class Movement : MonoBehaviour
    {
        public float HP;
        public AudioSource dashSFX;
        protected float horizontal;
        protected float movementSpeed;
        //Jump Variables
        public float jumpForce = 7.0f;
        public int maxJumps = 2;
        public Animator animator;

        protected Rigidbody2D rb;
        protected int jumpsRemaining;

        //Ground Stuff
        protected bool isGrounded;
        public Transform groundCheck;
        public LayerMask groundLayer;

        protected bool canFlip = true;
        protected bool canWalk = true;
        protected bool jumping = false;

        //Dash Variables
        public bool canDash = true;
        protected bool isFacingRight = true;
        private bool isDashing;
        private float dashingPower = 10f;
        private float dashingTime = 0.25f;
        private float dashingCooldown = 1f;
        private const float maxHP = 100;

        [SerializeField] private TrailRenderer tr;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        protected void Start()
        {
            jumpsRemaining = maxJumps;
            HP = maxHP;
        }

        protected void Update()
        {
            isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.58f, 0.27f), 0, groundLayer);

            // Move left/right
            horizontal = Input.GetAxisRaw("Horizontal");
            
            Jump();

            //Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
            {
                StartCoroutine(Dash());
                dashSFX.Play();
            }
            
            if (canFlip)
            {
                Flip();
            }
        }

        protected void FixedUpdate()
        {
            // Dash
            if (isDashing)
            {
                return;
            }

            if (canWalk)
            {
                rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
                if (!jumping)
                {
                    if (horizontal != 0f)
                    {
                        animator.Play("Walk");
                    }
                    else
                    {
                        animator.Play("Idle");
                    }
                }
            }
        }

        private void Flip()
        {
            if (horizontal < 0f)
            {
                Vector3 localScale = transform.localScale;
                isFacingRight = false;
                localScale.x = -Math.Abs(localScale.x);
                transform.localScale = localScale;
            }
            if (horizontal > 0f)
            {
                Vector3 localScale = transform.localScale;
                isFacingRight = true;
                localScale.x = Math.Abs(localScale.x);
                transform.localScale = localScale;
            }
            
            /*if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                Vector3 localScale = transform.localScale;
                isFacingRight = !isFacingRight;
                localScale.x *= -1f;
                transform.localScale = localScale;*/
                
                
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
                
           // }
            
        }

        protected abstract void Jump();

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
            if (collision.gameObject.CompareTag("Ground") || isGrounded)
            {
                jumpsRemaining = maxJumps;
                jumping = false;
            }
        }

        public void DealDamage(float damage)
        {
            HP -= damage;
        }
    }
}
