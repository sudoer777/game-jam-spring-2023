using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFairyScript : enemyScript
{
    private float shootTimer;
    private Vector3 startPosition;
    private Vector3 velocity;
    private Rigidbody2D rb;
    private SpriteRenderer sRenderer;

    public float movementRadius;
    public float movementSpeed;
    public float shootDelay;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        startPosition = transform.position;
        shootTimer = 0;
        velocity = (Vector3.up + Vector3.right).normalized * movementSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //destroy enemy if health falls below 0
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

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
        }

        //change vertical movement
        if (transform.position.y < startPosition.y - (movementRadius/2) && velocity.y < 0 || transform.position.y > startPosition.y + (movementRadius/2) && velocity.y > 0)
        {
            velocity.y *= -1;
        }

        //move
        rb.MovePosition(transform.position + velocity);
    }
}
