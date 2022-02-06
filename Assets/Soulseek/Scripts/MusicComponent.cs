using UnityEngine;

namespace Soulseek
{
    public class MusicComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource = null;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}