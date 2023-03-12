using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private GameObject bulletSelf;
    public float bulletSpeed;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Ground")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
