using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFairyScript : enemyScript
{
    private float leftXBound;

    public float movementRange;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        leftXBound = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(transform.position.x < leftXBound)
        {
            speed *= -1;
        }

        else if(transform.position.x > leftXBound + movementRange)
        {
            speed *= -1;
        }

        transform.position += Vector3.right * speed;
    }
}
