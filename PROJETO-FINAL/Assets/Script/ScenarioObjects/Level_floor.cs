using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_floor : MonoBehaviour
{
    private BoxCollider2D box;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            box.enabled = false;
            anim.SetTrigger("pull");
        }
    }

}
