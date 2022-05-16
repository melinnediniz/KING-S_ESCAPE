using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class LoadScenes : MonoBehaviour
    {
        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
