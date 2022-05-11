using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    private CircleCollider2D circ; //colisor
    private Animator anim;  //relações de animação
    // Start is called before the first frame update
    void Start()
    {
        circ = GetComponent<CircleCollider2D>();  //pega o colisor
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider){ //quando objeto colide com um colisor
        if(collider.gameObject.tag == "Player"){ //quando objeto colide com "Player"
            circ.enabled = false;  //desativa o colisor 
            anim.SetBool("hit", true);  //seta a animação "andando"

            Destroy(gameObject, 0.2f);
        }
    }
}
