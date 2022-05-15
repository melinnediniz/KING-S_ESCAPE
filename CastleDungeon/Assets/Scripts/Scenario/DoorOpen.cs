using Character;
using UnityEngine;
using UnityEngine.SceneManagement;

//biblioteca para manipular a cena

namespace Scenario
{
    public class DoorOpen : MonoBehaviour
    {
        private BoxCollider2D boxCol;
        private Animator anim;  //relações de animação
        public string lvlname;

        // Start is called before the first frame update
        void Start()
        {
            boxCol = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
        }

        void OnTriggerEnter2D(Collider2D collider) {
            if(collider.gameObject.tag == "Player"){ //quando objeto colide com "Player"
                boxCol.enabled = false;  //desativa o colisor 
                anim.SetTrigger("open");
                Player.instance.DoorIn();
                Invoke("ChangeScene", 1f);
            }
        }

        void ChangeScene(){
            SceneManager.LoadScene(lvlname);  //carrega a cenas
        }

    }
}
