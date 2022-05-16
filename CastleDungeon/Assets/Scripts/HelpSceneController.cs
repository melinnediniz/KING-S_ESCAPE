using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpSceneController : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
