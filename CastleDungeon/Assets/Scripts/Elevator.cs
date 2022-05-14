using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool move;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    void Update() {
        if(move){
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        if(timer >= moveTime){
            Destroy(gameObject, 0f);
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player"){ //quando objeto colide com "Player"
            move = true;
        }
    }

}
