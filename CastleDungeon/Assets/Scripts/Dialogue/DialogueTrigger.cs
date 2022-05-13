using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }
    public void TriggerDialogue ()
    {
        FindObjectOfType<TutorialManager>().StartDialogue(dialogue);
    }
}
