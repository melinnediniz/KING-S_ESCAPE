using UnityEngine;
using UnityEngine.SceneManagement;

//biblioteca para manipular a cena

namespace Controllers
{
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
}
