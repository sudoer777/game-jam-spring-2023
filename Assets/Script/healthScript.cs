using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    [SerializeField] public Image healthImage;
    [SerializeField] public float healthValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthValue <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        healthValue -= damage;
        healthImage.fillAmount = healthValue / 100f;
    }

    
}
