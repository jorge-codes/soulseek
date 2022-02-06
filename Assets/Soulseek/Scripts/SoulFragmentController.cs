using System;
using UnityEngine;

namespace Soulseek
{
    public class SoulFragmentController : MonoBehaviour
    {
        public event Action<SoulFragmentController, PlayerController> TakenByPlayer;
        [SerializeField] private string tagPlayer = "Player";
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.tag.Equals(tagPlayer)) return;
            
            gameObject.SetActive(false);
            var player = gameObject.GetComponent<PlayerController>();
            TakenByPlayer?.Invoke(this, player);
        }
    }
}