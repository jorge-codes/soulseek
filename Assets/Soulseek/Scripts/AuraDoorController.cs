
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Soulseek
{
    public class AuraDoorController : MonoBehaviour
    {
        [SerializeField] private SoulFragmentController[] soulFragments;
        [SerializeField] private string nextLevel;
        [SerializeField] private string tagPlayer = "Player";
        private int activated;

        private void Awake()
        {
            print($"AuraDoor Awake");
            activated = 0;
            gameObject.SetActive(false);
            foreach (var fragment in soulFragments)
            {
                fragment.TakenByPlayer += OnSoulFragmentTaken;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                GoToNextLevel();
            }
        }

        private void GoToNextLevel()
        {
            if (string.IsNullOrEmpty(nextLevel)) return;

            print($"LoadScene: {nextLevel}");
            SceneManager.LoadScene(nextLevel);
        }

        private void OnSoulFragmentTaken(SoulFragmentController fragment, PlayerController player)
        {
            print($"SoulFragmentTaken!");
            fragment.TakenByPlayer -= OnSoulFragmentTaken;
            activated += 1;
            if (activated == soulFragments.Length)
            {
                ActivateDoor();
            }
        }

        private void ActivateDoor()
        {
            print("ActivateDoor");
            gameObject.SetActive(true);
        }
    }
}