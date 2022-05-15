using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject gameOver;
    public GameObject pause;
    public bool isPaused;
 
    void Start()
    {
        Instance = this;
        TimerManager.Instance.StartTimer();
    }

    public void ShowGameOver()
    {
        TimerManager.Instance.StopTimer();
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
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
            Time.timeScale = 0f;
            AudioListener.pause = true;
            pause.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pause.SetActive(false);
        }
    }

}
