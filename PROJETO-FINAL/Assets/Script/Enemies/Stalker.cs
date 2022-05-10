using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
[SerializeField] private Transform target;
    public float agroRange; // quanto até ele ver o player
    public float speed;
    public int jumpForce = 6;
    public int health;
    public int currentHealth;

    private Rigidbody2D _rb2D;
    private Animator _anim;


    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckDistance();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _anim.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _anim.SetBool("die", true);
        Destroy(gameObject, 1f);
    }

    void CheckDistance()
    {
        float distPlayer = Vector2.Distance(transform.position, target.position);
        if(distPlayer < agroRange)
        {
            ChasePlayer();
            _anim.SetBool("isChasing", true);
        }
        else
        {
            StopChasing();
            _anim.SetBool("isChasing", false);
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < target.position.x) // esta na esquerda
        {
            _rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _rb2D.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _rb2D.velocity = new Vector2(-speed, 0);
        }
        
    }

    void StopChasing()
    {
        _rb2D.velocity = new Vector2(0, 0);
    }
}
