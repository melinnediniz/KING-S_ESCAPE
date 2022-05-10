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

    private Rigidbody2D rb2D;
    private Animator anim;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckDistance();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("die", true);
        Destroy(gameObject, 1f);
    }

    void CheckDistance()
    {
        float distPlayer = Vector2.Distance(transform.position, target.position);
        if(distPlayer < agroRange)
        {
            ChasePlayer();
            anim.SetBool("isChasing", true);
        }
        else
        {
            StopChasing();
            anim.SetBool("isChasing", false);
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < target.position.x) // esta na esquerda
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rb2D.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            rb2D.velocity = new Vector2(-speed, 0);
        }
        
    }

    void StopChasing()
    {
        rb2D.velocity = new Vector2(0, 0);
    }
}
