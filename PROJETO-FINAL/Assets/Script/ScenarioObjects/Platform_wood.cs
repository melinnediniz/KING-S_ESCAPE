using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_wood : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private SpriteRenderer spr;

    public float fallTime;
    public float restartTime;
    public Sprite plat_up;
    public Sprite plat_down;
    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Invoke("Fall", fallTime);
        }
    }

    void Fall(){
        spr.sprite = plat_down;
        boxCol.isTrigger = true;
        Invoke("Restart", restartTime);
    }

    void Restart(){
        boxCol.isTrigger = false;
        spr.sprite = plat_up;
    }

}
