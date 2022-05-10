using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;
    public float jumpForce;
    private bool isJumping;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
    
        if(movement > 0f)
        {
            transform.eulerAngles = new Vector3 (0f,0f,0f);
            anim.SetBool("run", true);
        }

        if(movement < 0f)
        {
            transform.eulerAngles = new Vector3 (0f,180f,0f);
            anim.SetBool("run", true);
        }

        if(movement == 0f)
        {
            anim.SetBool("run", false);
        }
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }
}
