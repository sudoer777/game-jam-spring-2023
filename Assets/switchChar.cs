using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchChar : MonoBehaviour
{
    private bool isSol;
    private SpriteRenderer switchSprite;
    // Start is called before the first frame update
    void Start()
    {
        
        switchSprite = GetComponent<SpriteRenderer>();
        switchSprite.color = new Color(1f, 0.8560839f, 0.3056604f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorSwitch();
        
    }

    void ColorSwitch()
    {
        if(Input.GetKeyUp(KeyCode.X))
        {
            isSol = !isSol;
            
            
        }
        if(isSol == true)
        {
            switchSprite.color = new Color(0.5607843f, 0.3058824f, 1f, 1f);
        }
        else if(isSol == false)
        {
            switchSprite.color = new Color(1f, 0.8560839f, 0.3056604f, 1f);
        }
    }
}
