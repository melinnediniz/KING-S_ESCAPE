using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //biblioteca para manipular a cena

public class MenuController : MonoBehaviour
{
    //public string scene;
    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);  //carrega a cenas
    }
}
