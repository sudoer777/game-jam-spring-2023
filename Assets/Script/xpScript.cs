using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class xpScript : MonoBehaviour
{
    [SerializeField] public Image xpImage;
    [SerializeField] public float maxXP = 10;
    [SerializeField] private float currentXP = 0;
    //[SerializeField] public float addXP = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && maxXP < 120f)
        {
            DebugXP(20);
        }
        if(maxXP == 120f)
        {
            maxXP = 0f;
            xpImage.fillAmount = 0f;
        }

    }

    void DebugXP(float testAdd)
    {
        maxXP += testAdd;
        xpImage.fillAmount = maxXP / 100f;
    }
}
