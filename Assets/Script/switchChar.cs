using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchChar : MonoBehaviour
{
    public Image healthRef;
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    private float switchCooldown = 2;
    public Camera playerCam;
    public MovementScript refMove;
    public attackScript refAttack;
    public shootScript refShoot;
    public GameObject backgroundObj;
    public GameObject buildingBackgroundObj;
    public GameObject buildingForegroundObj;
    public Sprite backgroundDay;
    public Sprite backgroundNight;
    public Sprite buildingBackgroundDay;
    public Sprite buildingBackgroundNight;
    public Sprite buildingForegroundDay;
    public Sprite buildingForegroundNight;

    private bool isSol;
    private float canSwitch = 0;

    private SpriteRenderer background;

    private SpriteRenderer buildingBackground;

    private SpriteRenderer buildingForeground;
    
    
    // private SpriteRenderer switchSprite;
    // Start is called before the first frame update
    void Start()
    {
        
        // switchSprite = GetComponent<SpriteRenderer>();
        // switchSprite.color = new Color(1f, 0.8560839f, 0.3056604f, 1f);
        healthRef.color = new Color(0.9622642f, 0.6039352f, 0.1942684f, 1f);

        background = backgroundObj.GetComponent<SpriteRenderer>();
        buildingBackground = buildingBackgroundObj.GetComponent<SpriteRenderer>();
        buildingForeground = buildingForegroundObj.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        ColorSwitch();
        
    }

    void ColorSwitch()
    {
        if(Time.time > canSwitch)
        {
            if(Input.GetKeyUp(KeyCode.X))
            {
                canSwitch = Time.time + switchCooldown;
                DoSlowMotion();
                //Time.timeScale = 0.25f;
                isSol = !isSol;
            
            
            }
            if(isSol)
            {
                // switchSprite.color = new Color(0.5607843f, 0.3058824f, 1f, 1f);
                healthRef.color = new Color(0.7830674f, 0.4849057f, 1f, 1f);
                // refMove.movementSpeed = 4;
                refShoot.enabled = false;
                refAttack.enabled = true;
                playerCam.backgroundColor = new Color(0.2711051f, 0.1718227f, 0.4622642f, 1f);

                background.sprite = backgroundNight;
                buildingBackground.sprite = buildingBackgroundNight;
                buildingForeground.sprite = buildingForegroundNight;
            }
            else if(!isSol)
            {
                // switchSprite.color = new Color(1f, 0.8560839f, 0.3056604f, 1f);
                healthRef.color = new Color(0.9622642f, 0.6039352f, 0.1942684f, 1f);
                // refMove.movementSpeed = 4;
                refShoot.enabled = true;
                refAttack.enabled = false;
                playerCam.backgroundColor = new Color(0.346351f, 0.5565226f, 0.8867924f, 1f);
                
                background.sprite = backgroundDay;
                buildingBackground.sprite = buildingBackgroundDay;
                buildingForeground.sprite = buildingForegroundDay;
            }
        }
    }
    void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
