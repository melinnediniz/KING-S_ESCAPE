using System;
using UnityEngine;

namespace Scenario
{
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

            if (hit.collider)
            {
                Fall();
            }

            Debug.DrawRay(transform.position, Vector2.down * rayLenght, Color.red);
        }

        void Fall()
        {
            Debug.Log("Fall");
            rb2D.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, 4f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
