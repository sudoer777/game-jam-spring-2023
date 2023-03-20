using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    //public AudioSource[] dialogues;
    //public GameObject[] images;
    public float textSpeed;

    private int index;
    private int imgIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        textComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(Input.GetMouseButtonDown(0))
        {
            
            if(textComponent.text == lines[index])
            {
                
                nextLine();
                
            }
            else
            {
                
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }

    public void startDialogue()
    {
        index = 0;
        
        StartCoroutine(TypeLine());
        //SoundPlayer.Instance.PlaySFX(dialogues, transform.position);

    }

    /*void startImages()
    {
        imgIndex = 0;
    }

    void nextImage()
    {
        if(index < images.Length - 1)
        {
            imgIndex++;
        }
    }
    */

    void nextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
