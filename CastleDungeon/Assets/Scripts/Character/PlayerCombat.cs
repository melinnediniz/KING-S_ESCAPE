using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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