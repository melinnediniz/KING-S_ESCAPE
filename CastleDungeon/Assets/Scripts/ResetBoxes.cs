using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBoxes : MonoBehaviour
{

    [SerializeField] private List<Transform> boxList;
    [SerializeField] private List<Vector3> boxPos;
    [SerializeField] private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        foreach (var t in boxList)
        {
            boxPos.Add(t.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("flip", true);
            ResetPosition();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("flip", false);
        }
    }

    private void ResetPosition()
    {
        for (int i = 0; i < boxList.Count; i ++)
        {
            boxList[i].position = boxPos[i];
        }
    }
    
    
}
