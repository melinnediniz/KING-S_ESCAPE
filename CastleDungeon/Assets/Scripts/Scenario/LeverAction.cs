using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D target;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float angle;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (target != null)
        {
            if (col.CompareTag("Player") && target.enabled)
            {
                anim.SetTrigger("activated");
                RotateTarget();
                target.enabled = false;
                
            }
            else if (!target.enabled)
            {
                anim.SetTrigger("activated");
                target.enabled = true;
            }
        }
    }

    void RotateTarget()
    {
        if (targetTransform.rotation.z == 0)
        {
            targetTransform.Rotate(Vector3.forward, angle);
        }
    }
}
