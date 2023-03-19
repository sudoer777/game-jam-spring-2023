using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = transform.right * -3f;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((originalPosition - transform.position).x >= sr.bounds.size.x / 2.0f)
        {
            Instantiate(gameObject, originalPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
