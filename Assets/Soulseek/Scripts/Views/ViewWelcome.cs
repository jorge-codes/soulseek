using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Soulseek.Views
{
    public class ViewWelcome : MonoBehaviour
    {
        [SerializeField] private string nextLevel;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return))
            {
                GoToNextLevel();
            }
        }

        public void GoToNextLevel()
        {
            if (string.IsNullOrEmpty(nextLevel)) return;

            SceneManager.LoadScene(nextLevel);
        }
    }
}