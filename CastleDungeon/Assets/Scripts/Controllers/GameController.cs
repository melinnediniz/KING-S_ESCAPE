using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        public GameObject gameOver;
        public GameObject pause;
        public GameObject restartButton;
        public GameObject pauseButton;
        public bool isPaused;
        public GameObject dialogue;
        
        private TimerManager _timer;
        private string _scene;
        private SaveGame _saveGame;

        private void Awake()
        {
            _timer = GameObject.Find("TimerManager").GetComponent<TimerManager>();
            _saveGame = GameObject.Find("SaveGame").GetComponent<SaveGame>();
           _scene = SceneManager.GetActiveScene().name;
        }

        void Start()
        {
            Time.timeScale = 1;
            _timer.StartTimer();
            _saveGame.SaveScene(_scene);
            Instance = this;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void ShowGameOver()
        {
            _timer.StopTimer();
            gameOver.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(_saveGame.LoadScene());
        }

        public void LoadScene(string scene)
        {
            Pause();
            SceneManager.LoadScene(scene);
        }
        

        public void Pause()
        {
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            isPaused = !isPaused;
            PauseGame();
        }
    
        private void PauseGame()
        {
            if(isPaused)
            {
                dialogue.SetActive(false);
                Time.timeScale = 0f;
                AudioListener.pause = true;
                pause.SetActive(true);
                restartButton.SetActive(false);
                pauseButton.SetActive(true);
            }
            else 
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                pause.SetActive(false);
                restartButton.SetActive(true);
            }
        }

    }
}
