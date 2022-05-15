using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class SaveGame: MonoBehaviour
    {
        public float lastTime;
        public string lastScene;
        public static SaveGame instance;

        private void Start()
        {
            instance = this;
        }
        

        public void SaveTime()
        {
            PlayerPrefs.SetFloat("Timer", lastTime);
        }

        public void SaveScene(string scene)
        {
            lastScene = scene;
            PlayerPrefs.SetString("Scene", this.lastScene);
        }

        public float LoadTime()
        {
            return PlayerPrefs.GetFloat("Timer");
        }

        public string LoadScene()
        {
            return PlayerPrefs.GetString("Scene");
        }
    }
}