using UnityEngine;

namespace Dialogue
{
    public class DialogueArea : MonoBehaviour
    {
    
        //[SerializeField] private Animator anim;
        [SerializeField] private GameObject warning;
        [SerializeField] private GameObject dialogueBox;
        public global::Dialogue.Dialogue dialogue;
        private int _count;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                TriggerDialogue();
                Destroy(warning, 0.5f);
            }
        }


        private void TriggerDialogue()
        {
            if (_count <= 0)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                _count += 1;
            }
        
        }
    
    }
}
