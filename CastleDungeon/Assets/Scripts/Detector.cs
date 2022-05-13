using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider) {
        ObjectFall.instance.Fall();
    }
}
