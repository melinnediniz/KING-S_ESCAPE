using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_floor : MonoBehaviour
{
    private Animator anim;  //variável para o componente Animator
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  // recebe o componente Animator
    }

    void LevelPull(){
        anim.SetTrigger("pull");  // ativa o trigger "pull" no animator (alavanca)
    }

}
