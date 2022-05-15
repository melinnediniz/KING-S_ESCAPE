using System;
using Character;
using UnityEngine;

namespace Scenario
{
    public class Ladder : MonoBehaviour
    {

        [SerializeField] private float speed;
        private float _vertical;
        private bool  _isUnder;
        
        private Rigidbody2D _rb2DPlayer;
        private Animator _playerAnim;

        private void Awake()
        {
            _playerAnim = GameObject.Find("Player").GetComponent<Animator>();
            _rb2DPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            speed = 5f;
        }

        // Update is called once per frame
        void Update()
        {
            _vertical = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            if (_rb2DPlayer)
            {
                Climb();
            }
           
        }

        private void Climb()
        {
            if (_isUnder)
            {
                _rb2DPlayer.velocity = new Vector2(_rb2DPlayer.velocity.x, _vertical * speed);
            }

        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _rb2DPlayer.gravityScale = 0f;
                _playerAnim.SetBool("climbing", true);
                _isUnder = true;
            }
        
        
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _playerAnim.SetBool("climbing", false);
                _isUnder = false; 
                _rb2DPlayer.gravityScale = 2f;

            }
        }
    }
}
