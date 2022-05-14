using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb2D;
    public bool isFacedToLeft;
    private int _dir;

    private void Start()
    {
        if (isFacedToLeft)
        {
            _dir = -1;
        }
        else
        {
            _dir = 1;
        }
        
        _rb2D = GetComponent<Rigidbody2D>();
        Move();
    }

    void Move()
    {
        Vector3 dir = new Vector3(_dir, 0, 0);
        _rb2D.velocity = (transform.right * dir.x) * speed;
        Destroy(gameObject, 2f);
    }
    
}
