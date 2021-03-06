using UnityEngine;

namespace Scenario
{
    public class Trampoline : MonoBehaviour
    {

        public float HorizontalJumpForce;
        public float VerticalJumpForce;

        private Animator anim;

        void Start() {
            anim = GetComponent<Animator>();
        }

        void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.tag == "Player"){
                anim.SetTrigger("jump");
                FindObjectOfType<AudioManager>().Play("Boing");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(VerticalJumpForce, HorizontalJumpForce), ForceMode2D.Impulse);
            }
        }

    }
}
