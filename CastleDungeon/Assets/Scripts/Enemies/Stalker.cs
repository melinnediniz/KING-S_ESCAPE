using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour 
{
    // components variables
    private Rigidbody2D rig;
    private Animator anim;
    public Transform player;

    // movement
    public float agroRange;
    public float speed;

    // life
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckDistance();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // animation hit
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // animation die
        Destroy(gameObject, 1f);
    }

    void CheckDistance()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            // animation walk
            ChasePlayer();
        }
        else
        {
            // animation idle
            StopChasing();
        }
    }

    void ChasePlayer()
    {  
        // enemy is in the left side of the player
        if (transform.position.x < player.position.x)
        {
            rig.velocity = new Vector2(speed, 0f);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        // enemy is in the right side of the player
        else if (transform.position.x > player.position.x)
        {
            rig.velocity = new Vector2(-speed, 0f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void StopChasing()
    {
        rig.velocity = new Vector2(0f, 0f);
    }
}