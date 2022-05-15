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
        private SaveGame _saveGame;

        [SerializeField] public float initialTime;

        [SerializeField] private Text timerText;
    
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            _saveGame = GameObject.Find("SaveGame").GetComponent<SaveGame>();
            initialTime = _saveGame.LoadTime();
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
                _saveGame.lastTime = _currentTime;
            }

            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            timerText.text = time.ToString(@"hh\:mm\:ss");
            _saveGame.SaveTime();
            
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
