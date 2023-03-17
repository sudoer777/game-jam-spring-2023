using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public bool isDead = false;
    public GameObject healthPickup;
    public GameObject xpPickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            Debug.Log("Enemy is Dead");
            Instantiate(healthPickup, transform.position, transform.rotation);
            Instantiate(xpPickup, transform.position, transform.rotation);
        }   
        
    }
}
