using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //biblioteca para manipular a cena

public class MenuController : MonoBehaviour
{
    public string lvlname;
    
    public void btPlay(){
        SceneManager.LoadScene("level_1");  //carrega a cenas
    }
}
