using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;
    public float jumpForce;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();    
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
        }

        if(movement < 0f)
        {
            transform.eulerAngles = new Vector3 (0f,180f,0f);
        }

        if(movement == 0f)
        {

        }
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
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
