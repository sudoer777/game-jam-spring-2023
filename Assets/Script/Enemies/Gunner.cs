using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Script.Enemies.Enemy
{
    public float movementRange;
    public float movementSpeed;
    public float shootDelay;
    public GameObject projectile;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float shootTimer;
    private Vector2 startPosition;
    private Vector2 velocity;

    // Start is called before the first frame update
    override protected void StartEnemy()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        shootTimer = 0;
        startPosition = rb.position;
        velocity = Vector2.right * movementSpeed;
        sr.flipX = true;
    }

    // Update is called once per frame
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
        //change direction
        if ((rb.position.x < startPosition.x && velocity.x < 0) || (rb.position.x > startPosition.x + movementRange && velocity.x > 0))
        {
            velocity.x *= -1;
            sr.flipX = !sr.flipX;
        }

        //move
        rb.MovePosition(rb.position + velocity);
    }
}
