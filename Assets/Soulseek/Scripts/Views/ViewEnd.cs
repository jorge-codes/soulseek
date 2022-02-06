using UnityEngine;
using UnityEngine.SceneManagement;

namespace Soulseek.Views
{
    public class ViewEnd : MonoBehaviour
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