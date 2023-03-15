using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Transform shootingPoint;
    
    public GameObject bulletPrefab;

    public GameObject chargedBullet;
    public float chargeSpeed;
    public float chargeTime;
    private bool isCharging;

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
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
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
