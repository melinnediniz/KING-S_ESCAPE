using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{

    [SerializeField] private float rayLenght;

    [SerializeField] private LayerMask targetLayerMask;

    [SerializeField] private Rigidbody2D rb2D;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLenght, targetLayerMask);

        if (hit.collider != null)
        {
            Fall();
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLenght, Color.red);
    }

    void Fall()
    {
        rb2D.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Killed");
            Destroy(gameObject, 0.2f);
        }

        if (col.gameObject.layer == 6)
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
