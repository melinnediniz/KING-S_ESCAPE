using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private bool _timer;
    public static TimerManager Instance;

    private float _currentTime;

    [SerializeField] public float initialTime = 0;
    public float lastTime;

    [SerializeField] private Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        initialTime = PlayerPrefs.GetFloat("lastTime");
        _currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

    private void RunTimer()
    {
        if (_timer)
        {
            _currentTime += Time.deltaTime;
            lastTime = _currentTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        timerText.text = time.ToString(@"hh\:mm\:ss");
        PlayerPrefs.SetFloat("lastTime", lastTime);
    }

    public void StartTimer()
    {
        _timer = true;
    }

    public void StopTimer()
    {
        _timer = false;
    }
}
