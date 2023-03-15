using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directedBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Vector3 velocity;

    public float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        velocity = (player.transform.position - gameObject.transform.position).normalized * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
