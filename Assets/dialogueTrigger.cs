using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueRef;
    public GameObject dialogueSystem;
    
    void Update()
    {
        //dialogueSystem.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueRef.startDialogue();

            

            

        }
        
        
    }
}
