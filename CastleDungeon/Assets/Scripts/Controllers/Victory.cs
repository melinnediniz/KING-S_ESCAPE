using System;
using System.ComponentModel.Design.Serialization;
using System.Net.Mime;
using Character;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace Controllers
{
    public class Victory : MonoBehaviour
    {
        public Text text;
        public void Text()
        {

            text.text = PlayerPrefs.GetFloat("Timer").ToString();
        }
    }
}
