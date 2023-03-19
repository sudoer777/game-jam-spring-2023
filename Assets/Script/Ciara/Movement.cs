using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Ciara
{
    public class Movement : Script.Player.Movement
    {
        public Transform upperFloatCheck;
        public Transform floatCheck;
        public Transform lowerFloatCheck;

        private bool upperFloatIsGrounded;
        private bool floatIsGrounded;
        private bool lowerFloatIsGrounded;

        private bool hoverMode = false;
        private bool jumpMode = false;
        private float maxHoverSpeed = 0.5f;

        // private float distanceFromGround;
        public void Update()
        {
            upperFloatIsGrounded = Physics2D.OverlapBox(upperFloatCheck.position, new Vector2(0.58f, 0.27f), 0, groundLayer);
            floatIsGrounded = Physics2D.OverlapBox(floatCheck.position, new Vector2(0.58f, 0.27f), 0, groundLayer);
            lowerFloatIsGrounded = Physics2D.OverlapBox(lowerFloatCheck.position, new Vector2(0.58f, 0.27f), 0, groundLayer);

            hoverMode = ((hoverMode && lowerFloatIsGrounded) || isGrounded) && !Input.GetButton("Jump");

            Hover();

            base.Update();
        }

        private void Hover()
        {
            if (hoverMode)
            {
                jumpsRemaining = maxJumps;
                var yVelocity = rb.velocity.y;
                if (Math.Abs(yVelocity) > maxHoverSpeed)
                {
                    rb.velocity = new Vector2(rb.velocity.x, maxHoverSpeed * (yVelocity / Math.Abs(yVelocity)));
                }
                rb.gravityScale =
                    isGrounded ? -1.0f :
                    lowerFloatIsGrounded ? 1.0f :
                    floatIsGrounded ? 2.0f :
                    5.0f;
            }
            else
            {
                rb.gravityScale = 2.0f;
            }
        }
    }
}



