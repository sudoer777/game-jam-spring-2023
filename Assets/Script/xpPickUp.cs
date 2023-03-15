using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpPickUp : MonoBehaviour
{
    [SerializeField] public xpScript xpRef;
    float xpAmt = 10;
    public float xpVar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xpVar = xpRef.maxXP;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //healthVar = healthRef.healthValue;
        if (other.gameObject.CompareTag("Player")) 
        {
            PickUp();
            Destroy(gameObject);
        }   
    }

    void PickUp()
    {
        
        //Check for Health < 100
        if(xpVar < 100)
        {
            xpRef.maxXP += xpAmt;
            xpRef.xpImage.fillAmount = xpRef.maxXP / 100f;
        }
        
    }
}
