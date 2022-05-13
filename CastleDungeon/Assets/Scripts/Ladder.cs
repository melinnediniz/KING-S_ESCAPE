using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    [SerializeField] private float speed;
    private float _vertical;
    [SerializeField] private Animator animPlayer;

    [SerializeField]
    private bool  isUnder;
    

    public Rigidbody2D rb2DPlayer;
    public Animator playerAnim;
    
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (rb2DPlayer)
        {
            Climb();
        }
           
    }

    private void Climb()
    {
        if (isUnder)
        {
            rb2DPlayer.gravityScale = 0f;
            rb2DPlayer.velocity = new Vector2(rb2DPlayer.velocity.x, _vertical * speed);
        }
        else
        {
            rb2DPlayer.gravityScale = 2f;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animPlayer.SetBool("climbing", true);
            isUnder = true;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animPlayer.SetBool("climbing", false);
            isUnder = false;
        }
    }


}
