using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{   
    private Rigidbody2D rig;

    public static ObjectFall instance;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        instance = this;
    }
    
    public void fall(){
        rig.bodyType = RigidbodyType2D.Dynamic;
    }
}
