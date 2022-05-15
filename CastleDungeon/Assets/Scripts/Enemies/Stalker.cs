using Character;
using UnityEngine;

namespace Enemies
{
    public class Stalker : MonoBehaviour 
    {
        // components variables
        private Rigidbody2D rig;
        private Animator anim;
        private GameObject player;

        // movement
        public float agroRange;
        public float speed;

        // life
        public float maxHealth;
        public float currentHealth;
        private bool isAlive = true;

        // combat
        public int attackDamage;

        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            player = GameObject.FindGameObjectWithTag("Player");
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
            isAlive = false;
            StopChasing();
            anim.SetBool("dead", true);
            Destroy(gameObject, 1f);
        }

        void CheckDistance()
        {
            if (player == null)
            {
                return;
            }

            float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (isAlive)
            {
                if (distToPlayer < agroRange)
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
        }

        void ChasePlayer()
        {
            // enemy is in the left side of the player
            if (transform.position.x < player.transform.position.x)
            {
                rig.velocity = new Vector2(speed, 0f);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            // enemy is in the right side of the player
            else if (transform.position.x > player.transform.position.x)
            {
                rig.velocity = new Vector2(-speed, 0f);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }

        void StopChasing()
        {
            rig.velocity = new Vector2(0f, 0f);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.GetComponent<Player>().TakeDamage(attackDamage);

                // enemy is in the left side of the player
                if (transform.position.x < player.transform.position.x)
                {
                    player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 2), ForceMode2D.Impulse);
                }

                // enemy is in the right side of the player
                else if (transform.position.x > player.transform.position.x)
                {
                    player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, 2), ForceMode2D.Impulse);
                }
            }

            if (collision.gameObject.CompareTag("Trap"))
            {
                currentHealth = 0;
            }
        }
    }
}