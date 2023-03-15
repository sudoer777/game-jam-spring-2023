using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dashCooldown : MonoBehaviour
{
    [SerializeField] private MovementScript moveRef;
    [SerializeField] public Image dashMeterImage;
    [SerializeField] public float dashValue;
    [SerializeField] public float dashAdd = 1;
    private bool isDash;
    //[SerializeField] public float smoothness = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDash = moveRef.canDash;
        if(Input.GetKeyDown(KeyCode.LeftShift) && isDash)
        {
            BoostLimit(100);
        }
        if(dashValue < 100)
        {
            Debug.Log("No Dash");
            dashValue += dashAdd;
            dashMeterImage.fillAmount = dashValue / 100f;
        }
    }

    public void BoostLimit(float Limit)
    {
        dashValue -= Limit;
        dashMeterImage.fillAmount = dashValue / 100f;
    }
    
}
