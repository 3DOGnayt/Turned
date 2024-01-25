using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [Serializable]
    public class RestartLevel
    {
        [SerializeField] private Button[] _restart;
        [SerializeField] private GameObject[] _panels;

        public Button[] Buttons => _restart;
        public GameObject[] Panels => _panels;

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}