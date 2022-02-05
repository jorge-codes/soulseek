
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Soulseek
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private string layerPlatformName = "Platform";
        [SerializeField] private string layerWallName = "Wall";
        [SerializeField] private string layerItemName = "Item";
        [Space(3)]
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float speed = 0.5f;
        [FormerlySerializedAs("jump")] [SerializeField] private float jumpForce = 100f;
        [Space(3)] [SerializeField] private SpriteRenderer[] spriteRenderers;
        private Vector2 direction;
        private bool oldJump;
        private bool newJump;
        private int layerPlatform;
        private float mass;

        private void Awake()
        {
            if (rigidBody == null)
            {
                Debug.LogError("No rigidbody assigned");
            }
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            var horizontal = (int)Input.GetAxisRaw("Horizontal");
            AdjustForward(horizontal, (int)direction.x);
            direction.x = horizontal;
            
            if (Input.GetButtonDown("Jump"))
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        

        private void OnCollisionEnter2D(Collision2D col)
        {
            
        }

        private void OnCollisionExit2D(Collision2D other)
        {
        
        }

        private void FixedUpdate()
        {
            
            direction.x = speed * Time.fixedDeltaTime * direction.x;
            direction.y = rigidBody.velocity.y;

            rigidBody.velocity = direction;
        }

        public void Initialize()
        {
            mass = rigidBody.mass;
            layerPlatform = LayerMask.NameToLayer("Platform");
            newJump = oldJump = false;
        }

        public void AdjustForward(int horizontalNew, int horizontalOld)
        {
            if (horizontalNew == horizontalOld) return;

            var flipHorizontal = horizontalNew < 0 ? true : false;
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = flipHorizontal;
            }
        }
        
    }
}
