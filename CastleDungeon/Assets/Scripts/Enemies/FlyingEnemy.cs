using Character;
using UnityEngine;

namespace Enemies
{
    public class FlyingEnemy : MonoBehaviour
    {
        private GameObject player;
        public Transform startingPoint;

        public int currentHealth = 1;
        public int attackDamage;
        public float speed;
        public bool chase = false;
        private bool isAlive = true;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                return;
            }
            if(chase == true && isAlive)
            {
                Chase();
            }
            else if (chase == false && isAlive)
            {
                ReturnStartPosition();
            }
            Flip();
        }

        private void Chase()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        private void ReturnStartPosition()
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime); 
        }

        private void Flip()
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else 
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // die animation
            isAlive = false;
            Destroy(gameObject, 1f);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
            }
        }
    }
}