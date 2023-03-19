using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Transform shootingPoint;
    
    public Rigidbody2D bulletPrefab;

    public GameObject chargedBullet;
    public float chargeSpeed;
    public float chargeTime;
    private bool isCharging;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && chargeTime  < 2)
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

            if (rb.transform.localScale.x < 0.0f)
            {
                bullet.velocity = Vector2.right * -10f;
            }
            else
            {
                bullet.velocity = Vector2.right * 10f;
            }
            //bulletPrefab.transform.localScale = new Vector3(transform.localScale.x, 0, 0);
            chargeTime = 0;
        }
        else if(Input.GetMouseButtonUp(0) && chargeTime >=2)
        {
            releaseCharge();
        }
    }

    void releaseCharge()
    {
        Instantiate(chargedBullet, shootingPoint.position, shootingPoint.rotation);
        isCharging = false;
        chargeTime = 0;
    }
}
