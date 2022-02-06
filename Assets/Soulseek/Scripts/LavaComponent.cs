using UnityEngine;

namespace Soulseek
{
    public class LavaComponent : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(playerTag))
            {
                var player = col.GetComponent<PlayerController>();
                player.GoBackToInitialPosition();
            }
        }
    }
}