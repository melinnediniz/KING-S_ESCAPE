using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class NewScene : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("level_1", LoadSceneMode.Single);
        }
    }
}
