using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

//biblioteca para manipular a cena

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {

        public SaveGame saveGame;
        public GameObject newGamePanel;
        public GameObject loadGameButton;

        public void Awake()
        {
            saveGame = GameObject.Find("SaveGame").GetComponent<SaveGame>();
        }

        public void Start()
        {
            Time.timeScale = 1f;
            if (PlayerPrefs.GetFloat("Timer") == 0f)
            {
                loadGameButton.SetActive(false);
            }
            else
            {
                loadGameButton.SetActive(true);
            }

            Debug.Log(PlayerPrefs.GetFloat("Timer") + " SCENE" + PlayerPrefs.GetString("Scene"));
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        public void LoadScene(){
            SceneManager.LoadScene(saveGame.LoadScene());  //carrega a cenas
        }

        public void NewGame()
        {
            saveGame.ClearHistory();
            SceneManager.LoadScene("Cutscene");
        }

        public void ShowNewGamePanel()
        {
            newGamePanel.SetActive(true);
        }

        public void CloseNewGamePanel()
        {
            newGamePanel.SetActive(false);
        }
        
    }
}
