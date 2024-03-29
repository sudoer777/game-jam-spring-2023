using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Asra
{
    public class Movement : Script.Player.Movement
    {
        
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

        private void Update()
        {
            rb.gravityScale = 2.0f;
            movementSpeed = 4.0f;

            // Wall Jump
            isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.3f, 0.84f), 0, wallLayer);

            if (isWallTouch && !isGrounded && horizontal != 0)
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
            
            canFlip = !isWallJumping;
            
            base.Update();
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

        private void FixedUpdate()
        {
            canWalk = !isWallJumping;
            
            if(isSliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

            }

            base.FixedUpdate();
        }
        private void StopWallJumping()
        {
            isWallJumping = false;
        }

        protected override void Jump()
        {
            if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
            {
                jumping = true;
                
                animator.Play("Jump", -1, 0.0f);
                
                //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsRemaining--;
            }
        }
    }
}



