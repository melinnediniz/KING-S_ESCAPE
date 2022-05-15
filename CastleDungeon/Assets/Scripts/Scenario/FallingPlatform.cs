using UnityEngine;

namespace Scenario
{
    public class FallingPlatform : MonoBehaviour
    {

        [SerializeField] private float fallingTime;
        [SerializeField] private float destroyTime;

        private TargetJoint2D _target;
        private BoxCollider2D _boxCollider;

        // Start is called before the first frame update
        void Start()
        {
            _target = GetComponent<TargetJoint2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Invoke("Falling", fallingTime);
            }

            if (collision.gameObject.layer == 6)
            {
                _target.enabled = true;
            
            }

        }

        void Falling()
        {
            _target.enabled = false;
            //_boxCollider.isTrigger = true;
            
            Destroy(gameObject, destroyTime);
        }
    }
}
