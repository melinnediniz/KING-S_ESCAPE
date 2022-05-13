using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private Queue<string> _phrases;
    void Start()
    {
        _phrases = new Queue<string>();
    }
    
}
