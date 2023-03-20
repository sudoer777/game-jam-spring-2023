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
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        override protected void StartEnemy()
        {
            startPosition = transform.position;
            shootTimer = 0;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (Vector2.up + Vector2.right).normalized * movementSpeed;
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

            //change horizontal movement
            if (transform.position.x < startPosition.x && rb.velocity.x < 0 || transform.position.x > startPosition.x + movementRadius && rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                sr.flipX = !sr.flipX;
            }

            //change vertical movement
            if (transform.position.y < startPosition.y - (movementRadius / 2) && rb.velocity.y < 0 || transform.position.y > startPosition.y + (movementRadius / 2) && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
            }
        }
    }
}
