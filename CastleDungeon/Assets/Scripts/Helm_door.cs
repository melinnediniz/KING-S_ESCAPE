using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helm_door : MonoBehaviour
{
    public GameObject door;
    public float time;
    public float speed;

    private CircleCollider2D circ;
    private Animator anim;
    private bool open;
    private float timer;

    void Start(){
        circ = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        open = false;
    }

    void Update() {
        if(open && timer<=time){
            door.transform.Translate(Vector2.right * speed * Time.deltaTime);
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            anim.SetTrigger("spin");
            circ.enabled = false;
            open = true;
        }
    }

}
