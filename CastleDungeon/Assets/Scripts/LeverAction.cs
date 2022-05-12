using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D target;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (target != null)
        {
            if (col.CompareTag("Player") && !target.isTrigger)
            {
                anim.SetTrigger("activated");
                target.isTrigger = true;
            }
            else if (target.isTrigger)
            {
                anim.SetTrigger("activated");
                target.isTrigger = true;
            }
        }
    }
}
