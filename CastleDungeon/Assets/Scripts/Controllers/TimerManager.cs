using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Controllers
{
    public class TimerManager : MonoBehaviour
    {
        private bool _timer;
        public static TimerManager Instance;

        private float _currentTime;

        [SerializeField] public float initialTime;

        [SerializeField] private Text timerText;
    
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            initialTime = SaveGame.instance.LoadTime();
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
                SaveGame.instance.lastTime = _currentTime;
            }

            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            timerText.text = time.ToString(@"hh\:mm\:ss");
            SaveGame.instance.SaveTime();
            
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
}
