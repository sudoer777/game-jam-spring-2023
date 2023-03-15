using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healScript : MonoBehaviour
{
    [SerializeField] public healthScript healthRef;
    float healAmt = 20;
    public float healthVar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthVar = healthRef.healthValue;
        
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
        if(healthVar < 100)
        {
            healthRef.healthValue += healAmt;
            healthRef.healthImage.fillAmount = healthRef.healthValue / 100f;
        }
        
    }
}
