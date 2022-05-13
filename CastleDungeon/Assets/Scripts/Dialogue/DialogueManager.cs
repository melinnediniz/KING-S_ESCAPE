using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _phrases;
    [SerializeField] private Text titleText;
    [SerializeField] private Text dialogueText;

    [SerializeField] private Animator anim;
    

    void Start () {
        _phrases = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        anim.SetBool("displayed", true);

        titleText.text = dialogue.title;

        _phrases.Clear();

        foreach (string sentence in dialogue.phrases)
        {
            _phrases.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (_phrases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string phrase = _phrases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeText(phrase));
    }

    IEnumerator TypeText (string phrase)
    {
        dialogueText.text = "";
        foreach (char letter in phrase)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("displayed", false);
    }
    
}
