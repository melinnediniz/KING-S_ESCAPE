using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    [SerializeField] private float speed;
    private float _vertical;

    [SerializeField]
    private bool  isUnder;

    [SerializeField]
    private bool isClimbing;

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
        CheckInput();
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb2DPlayer.gravityScale = 0f;
            rb2DPlayer.velocity = new Vector2(rb2DPlayer.velocity.x, _vertical * speed);
        }
        else
        {
            rb2DPlayer.gravityScale = 2f;
        }
    }

    private void CheckInput()
    {
        if (isUnder && Mathf.Abs(_vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isUnder = true;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isUnder = false;
            isClimbing = false;
        }
    }
}
