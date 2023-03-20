using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Enemies
{
    public class GunFairy : Script.Enemies.Enemy
    {
        public float movementRadius;
        public float movementSpeed;
        public float shootDelay;
        public GameObject projectile;

        private float shootTimer;
        private Vector3 startPosition;
        private Vector3 velocity;
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        override protected void StartEnemy()
        {
            startPosition = transform.position;
            shootTimer = 0;
            velocity = (Vector3.up + Vector3.right).normalized * movementSpeed;
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            sr.flipX = true;
        }

        override protected void UpdateEnemy()
        {
            //shoot projectile
            if (shootTimer >= shootDelay)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                shootTimer = 0;
            }
            shootTimer += Time.deltaTime;
        }
        private void FixedUpdate()
        {
            //change horizontal movement
            if (transform.position.x < startPosition.x && velocity.x < 0 || transform.position.x > startPosition.x + movementRadius && velocity.x > 0)
            {
                velocity.x *= -1;
                sr.flipX = !sr.flipX;
            }

            //change vertical movement
            if (transform.position.y < startPosition.y - (movementRadius / 2) && velocity.y < 0 || transform.position.y > startPosition.y + (movementRadius / 2) && velocity.y > 0)
            {
                velocity.y *= -1;
            }

            //move
            rb.MovePosition(transform.position + velocity);
        }
    }
}
