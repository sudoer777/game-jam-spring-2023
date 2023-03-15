using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScript : enemyScript
{
    private float shootTimer;
    private Vector3 startPosition;
    private Vector3 velocity;
    private Rigidbody2D rb;

    public float movementRange;
    public float movementSpeed;
    public float shootDelay;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        shootTimer = 0;
        startPosition = transform.position;
        velocity = Vector3.right * movementSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // PerformBehavior is called every frame
    override protected void PerformBehavior()
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
        if(transform.position.x < startPosition.x && velocity.x < 0 || transform.position.x > startPosition.x + movementRange && velocity.x > 0)
        {
            velocity.x *= -1;
        }
        rb.MovePosition(transform.position + velocity);
    }
}
