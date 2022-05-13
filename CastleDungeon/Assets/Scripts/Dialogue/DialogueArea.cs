using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public Dialogue dialogue;
    public Animator anim;
    private int _count;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("displayed", false);
        }
    }

    public void TriggerDialogue()
    {
        if (_count <= 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            _count += 1;
        }
    }
    
}
