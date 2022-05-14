using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool _dirRight;
    private float _timer;
    // Update is called once per frame
    void Update()
    {
        if(_dirRight){
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
        }else{
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }

        _timer += Time.deltaTime;
        
        if(_timer >= moveTime){
            _dirRight = !_dirRight;
            _timer = 0f;
        }

    }

}
