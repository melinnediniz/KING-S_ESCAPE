using Enemies;
using UnityEngine;

namespace Character
{
    public class PlayerCombat : MonoBehaviour
    {
        private Animator anim;
        public Transform attackPoint;
        public LayerMask enemyLayers;

        public float attackRange;
        public int attackDamage;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
            }
        }

        void Attack()
        {
            anim.SetTrigger("attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                // enemy layer collision
                if (enemy.gameObject.layer == 8)
                {
                    enemy.GetComponent<Stalker>().TakeDamage(attackDamage);

                    Transform enemyTransform = enemy.gameObject.GetComponent<Transform>();

                    // enemy is in the left side of the player
                    if (enemyTransform.position.x > this.transform.position.x)
                    {
                        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 2), ForceMode2D.Impulse);
                    }

                    // enemy is in the right side of the player
                    else if (enemyTransform.position.x < this.transform.position.x)
                    {
                        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, 2), ForceMode2D.Impulse);
                    }
                }

                else if (enemy.gameObject.layer == 10)
                {
                    enemy.gameObject.GetComponent<FlyingEnemy>().TakeDamage(attackDamage);
                }

                // box(obstacle) collision
                else if (enemy.gameObject.tag == "Box")
                {
                    Destroy(enemy.gameObject);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            // desenhar esfera do tamanho do attackRange
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}