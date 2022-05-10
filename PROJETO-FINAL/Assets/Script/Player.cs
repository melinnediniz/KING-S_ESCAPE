using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rig;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool _isJumping;
    
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();   
        _anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        _rig.velocity = new Vector2(movement * speed, _rig.velocity.y);
    
        if(movement > 0f)
        {
            transform.eulerAngles = new Vector3 (0f,0f,0f);
            _anim.SetBool("run", true);
        }

        if(movement < 0f)
        {
            transform.eulerAngles = new Vector3 (0f,180f,0f);
            _anim.SetBool("run", true);
        }

        if(movement == 0f)
        {
            _anim.SetBool("run", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!_isJumping)
            {
                _rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                _anim.SetBool("jump", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
            _anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = true;
        }
    }
}
